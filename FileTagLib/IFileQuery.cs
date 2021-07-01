namespace FileTagLib
{
    public interface IFileQuery
    {
        public bool MatchesQuery(TaggedFile file);
    }
}