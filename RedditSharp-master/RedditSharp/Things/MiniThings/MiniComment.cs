using System;
using RedditSharp.Master;
using RedditSharp.Things.VotableThings;
using ServiceStack.DataAnnotations;

namespace RedditSharp.Things.MiniThings
{
    public class MiniComment:MiniThing,IPost,IEquatable<Comment>
    {
        public string Author { get; set; }

        public string Subreddit { get; set; }

        public string ParentId { get; set; }

        public string Body { get; set; }

        public override string ShortLink { get; }

        public MiniComment(Comment c) : base(c)
        {
            Author = c.SafeAuthor;
            Subreddit = c.Subreddit??"unknown";
            ParentId = c.ParentId ?? c.LinkId;
            Body = c.Body;
            ShortLink = c.Shortlink;
        }

        public bool Equals(Comment other)
        {
            return ShortLink.GetHashCode() == other.Shortlink.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Body} by {Author} {base.ToString()}";
        }
    }
}