using System.IO;
using Xunit;

namespace FileTagLib.Tests
{
    public class TaggedFileTests
    {
        [Theory]
        [InlineData("HashTest.txt", "40F6C9227AAB58F1D36BDF2954571A50", 39)]
        public void TaggedFileTest(string path, string md5Hash, long fileSize)
        {
            var taggedFile = new TaggedFile(new FileInfo(path));

            Assert.Equal(md5Hash, taggedFile.HashMd5);
            Assert.Equal(fileSize, taggedFile.SizeBytes);
        }
    }
}
