using System;
using ServiceStack.DataAnnotations;

namespace RedditSharp.Things.MiniThings
{
    public interface IMini
    {
        int Upvotes { get; set; }
        string Id { get; set; }
        [Ignore]
        string ShortLink { get; }
       
        DateTime Created { get; set; }
    }
}