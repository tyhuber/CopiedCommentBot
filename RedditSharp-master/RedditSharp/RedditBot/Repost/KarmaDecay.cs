using System.Collections.Generic;
using HtmlAgilityPack;
using RedditSharp.Things.VotableThings;

namespace RedditSharp.RedditBot.Repost
{
    public class KarmaDecay
    {
        private const string KdBaseUrl = "http://karmadecay.com";

        public static void CheckPost(Post post)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlNode node;
            if (!CheckForPrevPosts(post, KdBaseUrl, web, out node)) return;
            CheckForDuplicates(post, node);
        }
        private static void CheckForDuplicates(Post post, HtmlNode node)
        {
            Table table = new Table(node.InnerText);
            if (!table.Any) return;
            List<Comment> comments;
            if (!post.GetFilteredComments(out comments))
            {
                return;
            }


            CheckHelper.FindCopiedComments(post, table.FilteredPosts);
        }

        private static bool CheckForPrevPosts(Post post, string kdBaseUrl, HtmlWeb web, out HtmlNode node)
        {
            //            Console.WriteLine($"{post.Title}");
            string kdUrl = $"{kdBaseUrl}/search?q={post.Url}";
            var doc = web.Load(kdUrl);
            node = doc.DocumentNode.SelectSingleNode(@"//textarea[@id=""share1""]");
            if (node != null) return true;
            return false;
        }

        /*                  try
                       {
                           comments = post.ListComments(100);
                       }
                       catch (Exception e)
                       {
                           Bot.Message($"[ERROR] - tried to get comments for {post.Title} but caught error {e}");
                           CheckedLogger.RemovePost(post);
                           return;
                       }*/

/*
        private static bool GetDuplicateComments(Post repost, List<Comment> cmnts)
        {
            throw new NotImplementedException();
//            Post otherPost;
//            List<Comment> prevTopCmnts;
//            if (!FilterHelper.FilterAndSortComments(repost, out prevTopCmnts))
//            {
//                Bot.Log($"No comments for post {repost.Url} meet filter requirements");
//                return false;
//            }
//            Comparer.MatchComments(cmnts, prevTopCmnts, repost);
//            return true;
        }
*/
       
    }
}