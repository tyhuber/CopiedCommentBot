using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using RedditSharp.Things.MiniThings;
using RedditSharp.Utils;
using RedditSharp.Master;

namespace RedditSharp.Things.VotableThings
{
    public class CommentComparer:IEqualityComparer<Comment>
    {
        private static Regex SubRedditRegex => new Regex(@"^(\s*/r/\w+\s*)$");
        public bool Equals(Comment x, Comment y)
        {
//            if (!x.IsValid() || !y.IsValid())
//            {
//                return false;
//            }
            if (ReferenceEquals(x, y)) return false;
            if (x.Shortlink.Equals(y.Shortlink))
            {
                return false;
            }
            if (x.SafeAuthor.Equals(y.SafeAuthor) && !x.SafeAuthor.Equals("deleted"))
            {
                return false;
            }
            if (SubRedditRegex.IsMatch(x.Body) || SubRedditRegex.IsMatch(y.Body)) return false;
            if (!x.TrimmedInvariant.Equals(y.TrimmedInvariant, StringComparison.OrdinalIgnoreCase)) return false;
            Reddit.Comments.Add(new MiniComment(x));
            Reddit.Comments.Add(new MiniComment(y));
            Log($"Copied comments found! \n\t {x} \n\t {y}");
            //            Reddit.Checker.Add(other);
            return true;
        }

        public int GetHashCode(Comment obj)
        {
            Log($"Getting hash code for {obj}");
//            var invariant = obj.TrimmedBody.ToLowerInvariant();
            Log($"Trimmed body = {obj.TrimmedInvariant}");
            int hash = obj.TrimmedInvariant.GetHashCode();
            Log($"Hash is {hash}");
            return hash;
        }

        private static void Log(string s)
        {
            Logger.WriteLine(s);
        }
    }
}