using System.Collections.Generic;
using System.IO;

namespace FileTagLib
{
    public class TaggedFile
    {
        public readonly string Location;
        public readonly string Name;
        public readonly string Extension;

        public readonly string FilePath;

        public readonly long SizeBytes;

        public readonly string HashMd5;

        public readonly List<string> Tags;
        public readonly Dictionary<string, object> Metadata;

        public TaggedFile(string location, string name, string extension, long? sizeBytes = null, string? hashMd5 = null, List<string>? tags = null, Dictionary<string, object>? metadata = null)
        {
            Location = location;
            Name = name;
            Extension = extension;

            FilePath = Path.Join(Location, $"{Name}.{Extension}");

            if (sizeBytes == null)
            {
                var fileInfo = new FileInfo(FilePath);
                SizeBytes = fileInfo.Length;
            }
            else
            {
                SizeBytes = (long)sizeBytes;
            }

            HashMd5 = hashMd5 ?? HashUtil.FileMd5Hash(FilePath);

            Tags = tags ?? new List<string>();
            Metadata = metadata ?? new Dictionary<string, object>();
        }

        public TaggedFile(string filePath, long? sizeBytes = null, string? hashMd5 = null, List<string>? tags = null, Dictionary<string, object>? metadata = null)
        {
            var fileInfo = new FileInfo(filePath);

            Location = fileInfo.DirectoryName!;
            Name = fileInfo.Name;
            Extension = fileInfo.Extension;

            FilePath = filePath;

            SizeBytes = sizeBytes ?? fileInfo.Length;

            HashMd5 = hashMd5 ?? HashUtil.FileMd5Hash(fileInfo);

            Tags = tags ?? new List<string>();
            Metadata = metadata ?? new Dictionary<string, object>();
        }
    }
}
