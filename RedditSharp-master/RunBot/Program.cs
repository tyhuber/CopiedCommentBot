using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedditSharp.Sets;
using RedditSharp.Utils;

namespace RunBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            bool clear = true;
            Logger.Init(Path.Combine(Environment.CurrentDirectory, "Log.txt"),
                Path.Combine(Environment.CurrentDirectory, "Error.txt"));
            for (int i = 0; i < 1; i++)
            {
                using (
                    var cList = new CommentSet(Path.Combine(Directory.GetCurrentDirectory(), "Comments.jsv")))
                using (var vList = new PostSet(Path.Combine(Directory.GetCurrentDirectory(), "Posts.jsv")))
                {

                    RedditSharp.RedditBot.Bot bot = new RedditSharp.RedditBot.Bot(vList, cList, false);
                    clear = false;
                }
            }
        }
    }
}
