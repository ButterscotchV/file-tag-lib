using Xunit;

namespace FileTagLib.Tests
{
    public class HashUtilTests
    {
        [Theory]
        [InlineData("HashTest.txt", "40F6C9227AAB58F1D36BDF2954571A50")]
        public void FileMd5HashTest(string path, string md5Hash)
        {
            Assert.Equal(md5Hash, HashUtil.FileMd5Hash(path));
        }
    }
}