using System;
using System.IO;
using System.Security.Cryptography;

namespace FileTagLib
{
    public static class HashUtil
    {
        public static string StreamMd5Hash(Stream stream)
        {
            using var md5 = MD5.Create();
            return Convert.ToHexString(md5.ComputeHash(stream));
        }

        public static string FileMd5Hash(string path)
        {
            using var stream = new BufferedStream(File.OpenRead(path));
            return StreamMd5Hash(stream);
        }

        public static string FileMd5Hash(FileInfo fileInfo)
        {
            using var stream = new BufferedStream(fileInfo.OpenRead());
            return StreamMd5Hash(stream);
        }
    }
}
