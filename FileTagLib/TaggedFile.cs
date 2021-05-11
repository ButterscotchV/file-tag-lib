using System.Collections.Generic;
using System.IO;

namespace FileTagLib
{
    public class TaggedFile
    {
        public readonly FileInfo FileInfo;

        public readonly string Location;
        public readonly string Name;
        public readonly string Extension;

        public readonly string FilePath;

        public readonly string HashMd5;
        public readonly long? SizeBytes;

        public readonly List<string> Tags;
        public readonly Dictionary<string, object> Metadata;

        public TaggedFile(FileInfo fileInfo, string hashMd5, long? sizeBytes = null, List<string>? tags = null, Dictionary<string, object>? metadata = null)
        {
            FileInfo = fileInfo;

            Location = fileInfo.DirectoryName!;
            Name = fileInfo.Name;
            Extension = fileInfo.Extension;

            FilePath = fileInfo.FullName;

            HashMd5 = hashMd5;
            SizeBytes = sizeBytes;

            Tags = tags ?? new List<string>();
            Metadata = metadata ?? new Dictionary<string, object>();
        }

        public TaggedFile(FileInfo fileInfo, List<string>? tags = null, Dictionary<string, object>? metadata = null) : this(fileInfo, HashUtil.FileMd5Hash(fileInfo), fileInfo.Length, tags, metadata)
        {
        }
    }
}
