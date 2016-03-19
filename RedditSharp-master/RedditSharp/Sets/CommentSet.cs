using RedditSharp.Things.MiniThings;
using RedditSharp.Things.VotableThings;

namespace RedditSharp.Sets
{
    public class CommentSet : VoteableSet<MiniComment>
    {
        public CommentSet(string path) : base(path)
        {
        }

        public bool Contains(Comment c)
        {
            return Contains(new MiniComment(c));
        }

        public bool Add(Comment c)
        {
            return Contains(new MiniComment(c));
        }
    }
}