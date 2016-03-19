using System.Collections.Generic;
using System.Linq;
using RedditSharp.Things.VotableThings;
using RedditSharp.Utils;

namespace RedditSharp.RedditBot.Repost
{
    public class CheckHelper
    {
        public static void FindCopiedComments(Post post, IEnumerable<Post> reposts)
        {
            foreach (var repost in reposts)
            {
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