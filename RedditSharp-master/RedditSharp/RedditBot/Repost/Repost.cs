using System;
using System.Linq;
using RedditSharp.Things.VotableThings;
using RedditSharp.Utils;

namespace RedditSharp.RedditBot.Repost
{
    public struct Repost
    {
        private readonly string[] _split;
        public string Title => _split[0];

        public string Link
            => Title.Split(new[] { "](" }, StringSplitOptions.RemoveEmptyEntries).Last().TrimEnd().TrimEnd(')');

        public Post Post
        {
            get
            {
                Post post = new Post();
                try
                {
                    post = Bot.Reddit.GetPost(new Uri(Link));
                }
                catch (Exception e)
                {
                    Logger.Error(e);
                }
                return post;
            }
        }

        public bool IsValid => Post != default(Post);
        
        public Repost(string line)
        {
            _split = line.Split('|');
            if (_split.Length != 5)
            {
                throw new IndexOutOfRangeException($"{line} split by | should have 5 values. It only has {_split.Length}");
            }
        }

        //        public bool PassFilter => Points > 100;

        //        public int Points
        //        {
        //            get
        //            {
        //                int tmp;
        //                if (int.TryParse(_split[1], out tmp)) return tmp;
        //                return -1;
        //            }
        //
        //        }

        //        public string Age => _split[2];
        //        public string Subreddit => _split[3];
        //
        //        public int Comments
        //        {
        //            get
        //            {
        //                int tmp;
        //                if (int.TryParse(_split[4], out tmp)) return tmp;
        //                return -1;
        //            }
        //        }

        //        private readonly string[] _split;



        //        public override string ToString()
        //        {
        //            return $"{Title}. +{Points}. Age - {Age}. Subreddit - {Subreddit}. # comments - {Comments}. Link - {Link}";
        //        }
    }
}