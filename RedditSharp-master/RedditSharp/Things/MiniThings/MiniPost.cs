using System;
using RedditSharp.Things.VotableThings;
using ServiceStack.DataAnnotations;

namespace RedditSharp.Things.MiniThings
{
    public class MiniPost:MiniThing,IPost,IEquatable<Post>
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Subreddit { get; set; }

        public MiniPost(Post p) : base(p)
        {
            Author = p?.AuthorName ?? "deleted";
            Title = p?.Title ?? "unknown";
            Subreddit = p?.SubredditName ?? "unknown";
        }

        public bool Equals(Post other)
        {
            return ShortLink.Equals(other.Shortlink);
        }

        public override string ToString()
        {
            return $"{Title} by {Author} {base.ToString()}";
        }
    }
}
