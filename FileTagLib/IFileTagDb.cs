using System.Collections.Generic;

namespace FileTagLib
{
    public interface IFileTagDb
    {
        public TaggedFile GetFile(int id);

        public int PutFile(TaggedFile file);

        public IEnumerator<TaggedFile> EnumerateFiles();

        public IEnumerator<TaggedFile> FindFiles(IFileQuery query);
    }
}
