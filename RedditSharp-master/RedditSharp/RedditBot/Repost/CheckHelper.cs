using System.Collections.Generic;
using System.Linq;
using RedditSharp.Master;
using RedditSharp.Things.VotableThings;
using RedditSharp.Utils;

namespace RedditSharp.RedditBot.Repost
{
    public class CheckHelper
    {
        public static void FindCopiedComments(Post post, IEnumerable<Post> reposts)
        {
            Reddit.Posts.Add(post);
            foreach (var repost in reposts)
            {
                Reddit.Posts.Add(repost);
                IEnumerable<Comment> copies;
                if (!post.GetDuplicates(repost, out copies))
                {
                    continue;
                }
                var list = copies.ToList();
                Logger.WriteLine($"*************Found {list.Count} reposts************");
                foreach (var c in list)
                {
                    Logger.WriteLine($"Copy = {c}");
                }
                

            }
        }
    }
}