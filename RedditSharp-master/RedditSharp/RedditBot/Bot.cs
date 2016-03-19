using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using RedditSharp.Master;
using RedditSharp.RedditBot.Repost;
using RedditSharp.Sets;
using RedditSharp.Things;
using RedditSharp.Things.MiniThings;
using RedditSharp.Things.Other;
using RedditSharp.Things.VotableThings;
using RedditSharp.Utils;

namespace RedditSharp.RedditBot
{
    public class Bot
    {
        public static Reddit Reddit { get; set; }
        private static AuthenticatedUser User { get; set; }
        public static bool SimpleCompareOnly = true;
        public static bool Verbose { get; set; }

        private const string CredentialstPath = @"C:\Reddit\Credentials.txt";
        //        public const int MinCommentLength = 8;

        public Bot(PostSet voteableSet, CommentSet cList,  bool clearCheckedPosts, bool simpleCompareOnly = true, bool verbose = true)
        {
            if(!File.Exists(CredentialstPath))throw new FileNotFoundException($"{CredentialstPath} does not exist");
            SimpleCompareOnly = simpleCompareOnly;
            Verbose = verbose;
            CheckedLogger.Init(Environment.CurrentDirectory, "Checked", clearCheckedPosts);
            Reddit = new Reddit();
            Reddit.Posts = voteableSet;
            Reddit.Comments = cList;
            var creds = File.ReadAllLines(CredentialstPath);
            User = Reddit.LogIn(creds[0], creds[1], checkPath: Path.Combine(Environment.CurrentDirectory, "Checked.xml"));
            var sub = Reddit.GetSubreddit("SciBotTest");//Reddit.RSlashAll;
//            var sub = Reddit.RSlashAll;
            CheckRecentPosts(sub);
            Logger.TearDown();
        }

        private static void CheckRecentPosts(Subreddit sub)
        {

            //            sub.Settings.ContentOptions=ContentOptions.LinkOnly;
            //            sub.Settings.UpdateSettings();
            var posts = sub.GetUncheckedPosts(100);//.GetListing(100, 100);
                                                   //            var posts = FilterHelper.FilterPosts(listingPosts, 100).ToList();//sub.Hot.Take(Constants.NumPostsToGet), 100).Distinct().ToList();//sub.Hot.Take(500)
            foreach (var post in posts)
            {
                post.GetCopiedComments();
                /*switch (post.PostType)
                {
                    case PostType.Link:
                        Log($"Checking post with url {post.Url} as an image post. \n\t{post}");

//                        LinkHelper.CheckPost(post);
                        break;
                    case PostType.Image:
                        Log($"Checking post with url {post.Url} as a link post. \n\t{post}");
                        KarmaDecay.CheckPost(post);
                        break;
                }*/
//                PercentReposts.Checked++;
                /* if (LinkTypes.IsKarmaDecayLink(post.Url))
                 {
                     Log($"Checking post with url {post.Url} as an image post. \n\t{StringHelper.PostToShortString(post)}");
                     KarmaDecay.CheckPost(post);
                 }
                 else if (LinkTypes.IsLink(post.Url))
                 {
                     Log($"Checking post with url {post.Url} as a link post. \n\t{StringHelper.PostToShortString(post)}");
                     LinkHelper.CheckPost(post);
                 }*/
                //                Reddit.Add(post);
                //                CheckedLogger.AddPost(post);

            }
        }

        public static void Message(string s, [CallerMemberName] string name = "", [CallerLineNumber] int ln = -1)
        {
            Logger.WriteLine(s, name, ln);
        }

        public static void Log(string s, [CallerMemberName] string name = "", [CallerLineNumber] int ln = -1)
        {
            if (Verbose)
            {
                Logger.WriteLine(s, name, ln);
            }
        }

        public static void Error(string s, [CallerMemberName] string name = "", [CallerLineNumber] int ln = -1)
        {
            Logger.Error(s, name, ln);
        }

        public static void Error(Exception e, [CallerMemberName] string name = "", [CallerLineNumber] int ln = -1)
        {
            Logger.Error(e, name, ln);
        }
    }
}