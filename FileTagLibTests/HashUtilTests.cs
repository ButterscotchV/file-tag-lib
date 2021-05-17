using System.IO;
using System.Text;
using Xunit;

namespace FileTagLib.Tests
{
    public class HashUtilTests
    {
        [Theory]
        [InlineData("This is a file to test hash generation.", "40F6C9227AAB58F1D36BDF2954571A50")]
        [InlineData("MD5 Hash Test", "4B918202BFF677BE19DAEFE035419674")]
        public void StringMd5HashTest(string text, string md5Hash)
        {
            Assert.Equal(md5Hash, HashUtil.StreamMd5Hash(new MemoryStream(Encoding.UTF8.GetBytes(text), false)));
        }

        [Theory]
        [InlineData("HashTest.txt", "40F6C9227AAB58F1D36BDF2954571A50")]
        public void FileMd5HashTest(string path, string md5Hash)
        {
            Assert.Equal(md5Hash, HashUtil.FileMd5Hash(path));
        }
    }
}