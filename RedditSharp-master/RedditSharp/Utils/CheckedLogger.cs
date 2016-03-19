using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using RedditSharp.Things;
using RedditSharp.Things.VotableThings;

namespace RedditSharp.Utils
{
    public static class CheckedLogger
    {
        public static string PostFile = "Posts.txt";
        public static string CommentFile = "Comments.txt";

        private static Regex _shortReg = new Regex(@"https\S+comments/");


        public static void Init(string dir, string name,bool clearFile = true)
        {
            PostFile = Path.Combine(dir,$"{name}Posts.txt");
            CommentFile = Path.Combine(dir, $"{name}Comments.txt");
            if (clearFile)
            {
                string tmp = String.Empty;
                File.WriteAllText(PostFile, tmp);
                File.WriteAllText(CommentFile, tmp);
            }
        }

        public static void RemovePost(Post post)
        {
            var tmp = File.ReadAllLines(PostFile).ToList();
            string id = GetId(post);
            if (tmp.Contains(id))
            {
                tmp.Remove(id);
                File.WriteAllLines(PostFile, tmp);
            }
        }
        public static void AddPost(Post post)
        {
            var tmp = File.ReadAllLines(PostFile).ToList();
            string id = GetId(post);
            if (!tmp.Contains(id))
            {
                tmp.Add(id);
                File.WriteAllLines(PostFile,tmp);
            }
        }

        public static bool CheckAdd(Post p)
        {
            var tmp = File.ReadAllLines(PostFile).ToList();
            string id = GetId(p);
            if (!tmp.Contains(id))
            {
                tmp.Add(id);
                File.WriteAllLines(PostFile, tmp);
                return true;
            }
            return false;
        }

        public static bool CheckAdd(Comment c)
        {
            var tmp = File.ReadAllLines(CommentFile).ToList();
            string id = $"{c.ParentId}.{c.Id}";
            if (!tmp.Contains(id))
            {
                tmp.Add(id);
                File.WriteAllLines(CommentFile, tmp);
                return true;
            }
            return false;
        }

        private static string GetId(Post post)
        {
            return post.Shortlink.Replace("http://redd.it/", String.Empty);
        }

        public static bool Checked(Post post)
        {
            if (!File.Exists(PostFile)) return false;
            var ids = File.ReadAllLines(PostFile).ToList();
            return ids.Contains(GetId(post));
        }
        public static bool Checked(Comment c)
        {
            if (!File.Exists(CommentFile)) return false;
            var ids = File.ReadAllLines(CommentFile).ToList();
            return ids.Contains($"{c.ParentId}.{c.Id}");
        }
    }
}
