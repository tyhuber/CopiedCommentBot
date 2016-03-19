using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using RedditSharp.Things.MiniThings;
using RedditSharp.Things.VotableThings;
using RedditSharp.Utils;

namespace RedditSharp.Sets
{
    public class PostSet : IEnumerable, IDisposable//VoteableSet<MiniPost>
    {
        protected HashSet<MiniPost> HashSet;
        protected string Path;
        public PostSet(string path)
        {
            Path = path;
            if (!File.Exists(Path))
            {
                Logger.WriteLine($"{Path} does not exist. Will begin checking comments from scratch");
                HashSet = new HashSet<MiniPost>();
                return;
            }
            HashSet = JsonHelper.DerializeJsv<HashSet<MiniPost>>(File.ReadAllText(path));

            foreach (var thing in HashSet)
            {
                Logger.WriteLine($"Deserialized {thing} from jsv.");
            }
        }

        public bool Contains(Post p)
        {
            var mini = new MiniPost(p);
            return Contains(mini);
        }

        public bool Contains(MiniPost mini)
        {
            if (!HashSet.Contains(mini))
            {
                Logger.WriteLine($"Set does not contain {mini}");
                Logger.WriteLine($"{this}");
                return false;
            }
            return true;
        }

        public bool Add(Post p)
        {
            var mini = new MiniPost(p);
            return Add(mini);
        }

        public bool Add(MiniPost mini)
        {
            if (HashSet.Add(mini))
            {
                Dispose();
                return true;
            }
            return false;
        }

        public IEnumerator GetEnumerator()
        {
            return HashSet.GetEnumerator();
        }

        public void Dispose()
        {
            File.WriteAllText(Path, JsonHelper.SerializeJsv(this));
        }

        public override string ToString()
        {
            return $"Set = {string.Join("\n\t", HashSet)}";
        }
    }
}