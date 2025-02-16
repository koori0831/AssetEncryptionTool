using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

namespace AssetEncryptionTool
{
    // 간단한 EndianBinaryReader (Little Endian 전제로 함)
    public class EndianBinaryReader : BinaryReader
    {
        public EndianBinaryReader(Stream input) : base(input) { }
        public new uint ReadUInt32() => base.ReadUInt32();
        public new byte[] ReadBytes(int count) => base.ReadBytes(count);
        public long Position
        {
            get => BaseStream.Position;
            set => BaseStream.Position = value;
        }
    }

    // 로그 출력을 위한 간단한 Logger
    public static class Logger
    {
        public static void Error(string message) => Console.Error.WriteLine(message);
        public static void Warning(string message) => Console.WriteLine("Warning: " + message);
    }

    // UnityCN 클래스 (복호화/암호화 핵심 로직)
    public class UnityCN
    {
        private const string Signature = "#$unity3dchina!@";
        private static ICryptoTransform Encryptor;
        private byte[] InvIndex = new byte[0x10]; // Index의 역매핑

        public byte[] Index = new byte[0x10];
        public byte[] Sub = new byte[0x10];

        // 복호화용 생성자: 헤더를 읽어 Index와 Sub를 설정함
        public UnityCN(EndianBinaryReader reader)
        {
            // 헤더 읽기 (4바이트 정수)
            reader.ReadUInt32();

            var infoBytes = reader.ReadBytes(0x10);
            var infoKey = reader.ReadBytes(0x10);
            reader.Position += 1; // 1바이트 건너뜀

            var signatureBytes = reader.ReadBytes(0x10);
            var signatureKey = reader.ReadBytes(0x10);
            reader.Position += 1; // 1바이트 건너뜀

            DecryptKey(signatureKey, signatureBytes);

            var str = Encoding.UTF8.GetString(signatureBytes);
            Console.WriteLine("Decrypted Signature: " + str);
            if (str != Signature)
                throw new Exception("Invalid Signature !!");

            DecryptKey(infoKey, infoBytes);

            infoBytes = infoBytes.ToUInt4Array();
            infoBytes.AsSpan(0, 0x10).CopyTo(Index);
            var subBytes = infoBytes.AsSpan(0x10, 0x10);
            for (var i = 0; i < subBytes.Length; i++)
            {
                var idx = (i % 4 * 4) + (i / 4);
                Sub[idx] = subBytes[i];
            }

            ComputeInvIndex();
        }

        // 암호화용 생성자: 기존 헤더(Index, Sub)를 그대로 사용
        public UnityCN(byte[] index, byte[] sub)
        {
            if (index.Length != 0x10 || sub.Length != 0x10)
                throw new Exception("Invalid header data.");
            Index = index;
            Sub = sub;
            ComputeInvIndex();
        }

        // Index 배열의 역매핑(InvIndex) 계산 (0~15의 순열이라고 가정)
        private void ComputeInvIndex()
        {
            for (int i = 0; i < 0x10; i++)
            {
                for (int j = 0; j < 0x10; j++)
                {
                    if (Index[j] == i)
                    {
                        InvIndex[i] = (byte)j;
                        break;
                    }
                }
            }
        }

        // AES 키 설정 (Entry에서 16진수 문자열을 변환)
        public static bool SetKey(Entry entry)
        {
            try
            {
                using (var aes = Aes.Create())
                {
                    aes.Mode = CipherMode.ECB;
                    aes.Key = entry.GenerateKey();
                    Encryptor = aes.CreateEncryptor();
                }
            }
            catch (Exception e)
            {
                Logger.Error($"[UnityCN] Invalid key !!\n{e.Message}");
                return false;
            }
            return true;
        }

        // 헤더의 key 데이터를 복호화 (XOR 연산, AES 변환 결과와 결합)
        private void DecryptKey(byte[] key, byte[] data)
        {
            if (Encryptor != null)
            {
                var transformed = Encryptor.TransformFinalBlock(key, 0, key.Length);
                for (int i = 0; i < 0x10; i++)
                    data[i] ^= transformed[i];
            }
        }

        // 블록 단위 복호화 (내부 Decrypt 메서드를 반복 호출)
        public void DecryptBlock(Span<byte> bytes, int size, int index)
        {
            int offset = 0;
            while (offset < size)
                offset += Decrypt(bytes.Slice(offset), index++, size - offset);
        }

        // 블록 단위 암호화 (Decrypt의 역연산을 수행한다고 가정)
        public void EncryptBlock(Span<byte> bytes, int size, int index)
        {
            int offset = 0;
            while (offset < size)
                offset += Encrypt(bytes.Slice(offset), index++, size - offset);
        }

        // DecryptByte: 복호화 시 한 바이트 단위 변환
        private int DecryptByte(Span<byte> bytes, ref int offset, ref int index)
        {
            int b = Sub[((index >> 2) & 3) + 4] + Sub[index & 3] + Sub[((index >> 4) & 3) + 8] + Sub[((byte)index >> 6) + 12];
            byte cur = bytes[offset];
            // lower nibble와 higher nibble에 대해 Index 배열을 참조 후 b를 뺀 결과를 재조합
            byte decrypted = (byte)(((Index[cur & 0xF] - b) & 0xF) | (0x10 * ((Index[cur >> 4] - b) & 0xF)));
            bytes[offset] = decrypted;
            b = decrypted;
            offset++;
            index++;
            return b;
        }

        // Decrypt: variable-length 데이터 복호화 (제어값을 이용)
        private int Decrypt(Span<byte> bytes, int index, int remaining)
        {
            int offset = 0;
            int curByte = DecryptByte(bytes, ref offset, ref index);
            int byteHigh = curByte >> 4;
            int byteLow = curByte & 0xF;

            if (byteHigh == 0xF)
            {
                int b;
                do
                {
                    b = DecryptByte(bytes, ref offset, ref index);
                    byteHigh += b;
                } while (b == 0xFF);
            }

            offset += byteHigh;

            if (offset < remaining)
            {
                DecryptByte(bytes, ref offset, ref index);
                DecryptByte(bytes, ref offset, ref index);
                if (byteLow == 0xF)
                {
                    int b;
                    do
                    {
                        b = DecryptByte(bytes, ref offset, ref index);
                    } while (b == 0xFF);
                }
            }
            return offset;
        }

        // EncryptByte: 암호화 시 한 바이트 단위 변환 (DecryptByte의 역연산을 수행)
        private int EncryptByte(Span<byte> bytes, ref int offset, ref int index)
        {
            int b = Sub[((index >> 2) & 3) + 4] + Sub[index & 3] + Sub[((index >> 4) & 3) + 8] + Sub[((byte)index >> 6) + 12];
            byte cur = bytes[offset];
            // decrypted 값에 b를 더한 후, InvIndex 배열을 사용하여 원래의 nibble 값을 복원
            byte encryptedLow = InvIndex[((cur & 0xF) + b) & 0xF];
            byte encryptedHigh = InvIndex[(((cur >> 4) & 0xF) + b) & 0xF];
            byte encrypted = (byte)((encryptedHigh << 4) | encryptedLow);
            bytes[offset] = encrypted;
            int result = encrypted;
            offset++;
            index++;
            return result;
        }

        // Encrypt: Decrypt의 역순 구조로 암호화 (데모용 구현)
        private int Encrypt(Span<byte> bytes, int index, int remaining)
        {
            int offset = 0;
            int curByte = EncryptByte(bytes, ref offset, ref index);
            int byteHigh = curByte >> 4;
            int byteLow = curByte & 0xF;

            if (byteHigh == 0xF)
            {
                int b;
                do
                {
                    b = EncryptByte(bytes, ref offset, ref index);
                    byteHigh += b;
                } while (b == 0xFF);
            }

            offset += byteHigh;

            if (offset < remaining)
            {
                EncryptByte(bytes, ref offset, ref index);
                EncryptByte(bytes, ref offset, ref index);
                if (byteLow == 0xF)
                {
                    int b;
                    do
                    {
                        b = EncryptByte(bytes, ref offset, ref index);
                    } while (b == 0xFF);
                }
            }
            return offset;
        }

        // 내부 클래스 Entry: AES 키(16진수 문자열)와 이름을 보관
        public class Entry
        {
            public string Name { get; private set; }
            public string Key { get; private set; }

            public Entry(string name, string key)
            {
                Name = name;
                Key = key;
            }

            public bool Validate()
            {
                var bytes = GenerateKey();
                if (bytes.Length != 0x10)
                {
                    Logger.Warning($"[UnityCN] {this} has invalid key, size should be 16 bytes, skipping...");
                    return false;
                }
                return true;
            }

            public byte[] GenerateKey() => ConvertHexStringToByteArray(Key);

            private static byte[] ConvertHexStringToByteArray(string hexString)
            {
                if (hexString.Length % 2 != 0)
                    throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
                byte[] data = new byte[hexString.Length / 2];
                for (int index = 0; index < data.Length; index++)
                {
                    string byteValue = hexString.Substring(index * 2, 2);
                    data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
                }
                return data;
            }

            public override string ToString() => $"{Name} ({Key})";
        }
    }
}
