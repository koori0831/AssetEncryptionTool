using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AssetEncryptionTool
{
    [Flags]
    public enum ArchiveFlags
    {
        CompressionTypeMask = 0x3f,
        BlocksAndDirectoryInfoCombined = 0x40,
        BlocksInfoAtTheEnd = 0x80,
        OldWebPluginCompatibility = 0x100,
        BlockInfoNeedPaddingAtStart = 0x200,
        UnityCNEncryption = 0x400
    }
    public static class Extensions
    {

        public static string ReadStringToNull(this BinaryReader reader, int maxLength = 32767)
        {
            var bytes = new List<byte>();
            int count = 0;
            while (reader.BaseStream.Position != reader.BaseStream.Length && count < maxLength)
            {
                var b = reader.ReadByte();
                if (b == 0)
                {
                    break;
                }
                bytes.Add(b);
                count++;
            }
            return Encoding.UTF8.GetString(bytes.ToArray());
        }
    }
    class Program
    {
        public class Header
        {
            public string signature;
            public uint version;
            public string unityVersion;
            public string unityRevision;
            public long size;
            public uint compressedBlocksInfoSize;
            public uint uncompressedBlocksInfoSize;
            public ArchiveFlags flags;
        }
        static void Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: AssetEncryptionTool.exe [decrypt|encrypt] <inputFile> <outputFile> <AESKey>");
                return;
            }

            string mode = args[0];
            string inputFile = args[1];
            string outputFile = args[2];
            string aesKey = args[3];

            // 파일 전체 읽기
            byte[] fileData = File.ReadAllBytes(inputFile);

            // AES 키 설정
            var entry = new UnityCN.Entry("Default", aesKey);
            if (!UnityCN.SetKey(entry))
            {
                Console.WriteLine("Failed to set AES key.");
                return;
            }

            if (mode.ToLower() == "decrypt")
            {
                using (var ms = new MemoryStream(fileData))
                {
                    var reader = new EndianBinaryReader(ms);

                    Header m_Header = new Header();
                    m_Header.signature = reader.ReadStringToNull();
                    m_Header.version = reader.ReadUInt32();
                    m_Header.unityVersion = reader.ReadStringToNull();
                    m_Header.unityRevision = reader.ReadStringToNull();
                    switch (m_Header.signature)
                    {
                        case "UnityArchive":
                            break; //TODO
                        case "UnityWeb":
                        case "UnityRaw":
                            throw new Exception("Unsupported format: " + m_Header.signature);
                            // if (m_Header.version == 6)
                            // {
                            //     goto case "UnityFS";
                            // }
                            // ReadHeaderAndBlocksInfo(reader);
                            // using (var blocksStream = CreateBlocksStream(reader.FullPath))
                            // {
                            //     ReadBlocksAndDirectory(reader, blocksStream);
                            //     ReadFiles(blocksStream, reader.FullPath);
                            // }
                            break;
                        case "UnityFS":
                            ReadHeader(reader, m_Header);
                            long readerPostion = reader.Position;
                            reader.Position = 0;
                            byte[] headerData = reader.ReadBytes((int)readerPostion);
                            reader.Position = readerPostion;
                            Console.WriteLine("Header Position: " + readerPostion);
                            // ReadUnityCN(reader);


                            ChangeFlang(headerData, ArchiveFlags.UnityCNEncryption);

                            {

                                UnityCN unityCn = null;
                                try
                                {
                                    // 헤더를 읽어 복호화를 위한 UnityCN 인스턴스를 생성
                                    unityCn = new UnityCN(reader);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("Decryption failed: " + ex.Message);
                                    return;
                                }

                                // 헤더 이후 나머지 데이터 읽기
                                long remainingLength = ms.Length - ms.Position;
                                byte[] remainingData = new byte[remainingLength];
                                reader.Read(remainingData, 0, (int)remainingLength);

                                // 블록 단위 복호화 수행
                                Span<byte> dataSpan = remainingData.AsSpan();
                                unityCn.DecryptBlock(dataSpan, remainingData.Length, 0);

                                // 여기서는 복호화된 본문만 출력 (필요에 따라 헤더와 결합 가능)
                                File.WriteAllBytes(outputFile, headerData.Concat(dataSpan.ToArray()).ToArray());
                                Console.WriteLine("Asset file decrypted successfully.");
                            }
                            // ReadBlocksInfoAndDirectory(reader);
                            // using (var blocksStream = CreateBlocksStream(reader.FullPath))
                            // {
                            //     ReadBlocks(reader, blocksStream);
                            //     ReadFiles(blocksStream, reader.FullPath);
                            // }
                            break;
                    }
                }
            }
            else if (mode.ToLower() == "encrypt")
            {
                // 암호화의 경우, 수정된(복호화된) 에셋 파일을 다시 암호화함
                // 헤더 정보(Index, Sub)는 원본 asset 파일 등에서 가져와야 합니다.
                // 이 예제에서는 "original.asset"이라는 파일에서 헤더를 읽어옵니다.
                string headerFile = "original.asset";
                if (!File.Exists(headerFile))
                {
                    Console.WriteLine("Header file (original.asset) not found for encryption.");
                    return;
                }
                byte[] headerData = File.ReadAllBytes(headerFile);
                using (var headerStream = new MemoryStream(headerData))
                {
                    var headerReader = new EndianBinaryReader(headerStream);
                    UnityCN unityCnHeader = null;
                    try
                    {
                        unityCnHeader = new UnityCN(headerReader);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Failed to read header: " + ex.Message);
                        return;
                    }

                    // 헤더의 Index와 Sub를 이용하여 암호화에 사용할 UnityCN 인스턴스 생성
                    UnityCN unityCn = new UnityCN(unityCnHeader.Index, unityCnHeader.Sub);

                    // 수정된(복호화된) 에셋 파일 읽기
                    byte[] modifiedData = File.ReadAllBytes(inputFile);
                    Span<byte> dataSpan = modifiedData.AsSpan();
                    unityCn.EncryptBlock(dataSpan, modifiedData.Length, 0);

                    // 암호화된 데이터 출력 (필요에 따라 헤더와 결합)
                    File.WriteAllBytes(outputFile, dataSpan.ToArray());
                    Console.WriteLine("Asset file encrypted successfully.");
                }
            }
            else
            {
                Console.WriteLine("Invalid mode specified. Use 'decrypt' or 'encrypt'.");
            }
        }
        /// <summary>
        /// change flag UnityCN to UnityFS
        /// </summary>
        /// <param name="headerData"></param>
        /// <param name="v"></param>
        private static void ChangeFlang(byte[] headerData, ArchiveFlags ignoreFlag)
        {
            int flagIndex = headerData.Length - 4;
            ArchiveFlags prevFlag = (ArchiveFlags)BitConverter.ToUInt32(headerData, flagIndex);
            ArchiveFlags newFlag = prevFlag ^ ignoreFlag;
            Byte[] newFlagByte = BitConverter.GetBytes((UInt32)newFlag);
            for (int i = 0; i < 4; i++)
            {
                headerData[flagIndex + i] = newFlagByte[i];
            }
        }


        private static void ReadHeader(EndianBinaryReader reader, Header m_Header)
        {
            m_Header.size = reader.ReadInt64();
            m_Header.compressedBlocksInfoSize = reader.ReadUInt32();
            m_Header.uncompressedBlocksInfoSize = reader.ReadUInt32();
            m_Header.flags = (ArchiveFlags)reader.ReadUInt32();
            if (m_Header.signature != "UnityFS")
            {
                reader.ReadByte();
            }
        }
    }
}
