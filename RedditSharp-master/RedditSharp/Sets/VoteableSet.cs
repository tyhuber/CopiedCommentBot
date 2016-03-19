using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using RedditSharp.Things.MiniThings;
using RedditSharp.Utils;

namespace RedditSharp.Sets
{
    public abstract class VoteableSet<T> : IEnumerable, IDisposable where T:MiniThing
    {
        protected HashSet<T> HashSet;
        protected string Path;

        public bool Add(T t)
        {
            if (HashSet.Add(t))
            {
                Dispose();
                return true;
            }
            return false;
        }

        public bool Contains(T t)
        {
            return HashSet.Contains(t);
        }

        public IEnumerator GetEnumerator()
        {
            return HashSet.GetEnumerator();
        }

        protected VoteableSet(string path)
        {
            Path = path;
            if (!File.Exists(Path))
            {
                HashSet=new HashSet<T>();
                return;
            }
            HashSet = JsonHelper.DerializeJsv<HashSet<T>>(File.ReadAllText(path));

            foreach (var thing in HashSet)
            {
                Logger.WriteLine($"Deserialized {thing} from jsv.");
            }
        }

        public void Dispose()
        {
            File.WriteAllText(Path,JsonHelper.SerializeJsv(this));
        }
    }
}