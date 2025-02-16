using System;

namespace AssetEncryptionTool
{
    public static class ByteExtensions
    {
        public static byte[] ToUInt4Array(this byte[] bytes)
        {
            // 각 바이트를 상위 nibble와 하위 nibble로 분리하여 2배 길이의 배열 생성
            byte[] result = new byte[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                result[i * 2] = (byte)(bytes[i] >> 4);      // 상위 nibble
                result[i * 2 + 1] = (byte)(bytes[i] & 0xF);   // 하위 nibble
            }
            return result;
        }
    }
}