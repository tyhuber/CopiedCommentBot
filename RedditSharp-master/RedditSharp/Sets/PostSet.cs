using RedditSharp.Things.MiniThings;
using RedditSharp.Things.VotableThings;

namespace RedditSharp.Sets
{
    public class PostSet : VoteableSet<MiniPost>
    {
        public PostSet(string path) : base(path)
        {

        }

        public bool Contains(Post p)
        {
            return Contains(new MiniPost(p));
        }

        public bool Add(Post p)
        {
            return Add(new MiniPost(p));
        }
    }
}