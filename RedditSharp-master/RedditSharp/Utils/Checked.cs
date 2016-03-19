using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using RedditSharp.Things;
using RedditSharp.Things.MiniThings;
using RedditSharp.Things.VotableThings;

namespace RedditSharp.Utils
{
    /*[XmlRoot("Checked")]
    public class Checked:IDisposable
    {
        [XmlIgnore]
        private string _path;

//        [XmlArray("Posts"), XmlArrayItem("id")]
//        public HashSet<string> Posts { get; set; }
//        [XmlArray("CopiedComments"), XmlArrayItem("id")]
//        public HashSet<string> CopiedComments { get; set; }
//        [XmlAttribute("CheckedCount")]
//        public int NumChecked => Posts.Count;
//        [XmlAttribute("CopiedCount")]
//        public int NumCopied => Posts.Count;
        [XmlElement("Posts")]
        public PostSet Posts { get; set; }
        [XmlElement("Copies")]
        public CommentSet CopiedComments { get; set; }

        [XmlIgnore]
        protected XmlSerializer Ser = new XmlSerializer(typeof(Checked));

        public void Init(string path)
        {
            _path = path;
            Console.WriteLine($"Set checker path to {_path}");
            Deserialize();
        }

        /// <summary>
        /// Return false if post is already in HashSet
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool Add(Post p)
        {
            if (Posts.Add(p.Id))
            {
                Serialize();
                return true;
            }
            return false;
        }

        public bool Add(Comment p,Comment c)
        {
            return CopiedComments.Add(p,c);
        }

        public bool Contains(Post p)
        {
            return Posts.Contains(p.Id);
        }

        public bool Contains(Comment c)
        {
            return CopiedComments.Contains(c);
        }



        private void Serialize()
        {
            using (var writer = new StreamWriter(_path))
            {
                Ser.Serialize(writer, this);
            }
        }
        private void Deserialize()
        {
            Posts=new PostSet();
            CopiedComments=new CommentSet();
            Console.WriteLine($"Deserialzing posts and copied comments from {_path}");
            if (!File.Exists(_path))
            {
                Console.WriteLine($"Checked path {_path} does not exist.");
                return;
            }
            using (var reader = new StreamReader(_path))
            {
                try
                {
                    
                    var tmp = (Checked)Ser.Deserialize(reader);
                    Posts = tmp.Posts;
                    Console.WriteLine($"Deserialized {Posts.Count} posts");
                    CopiedComments = tmp.CopiedComments;
                    Console.WriteLine($"Deserialized {CopiedComments.Pair.Count} copied  omments");
                }
                catch (Exception e)
                {
                    throw new InvalidDataException($"{_path} not a valid xml. Exception - {e}");
                }
            }
        }

        public void Dispose()
        {
            Serialize();
        }
    }

    public class CommentSet
    {
        [XmlArray("Copied")]
         public HashSet<Pair> Pair { get; set; }

        public bool Contains(Comment c)
        {
            //            Pair tmp = CreatePair(c, p);
            if (Pair == null)
            {
                Pair=new HashSet<Pair>();
                return false;
            }
            return Pair.Any(x => x.Copy.Equals(CreateMini(c)));
        }

        public bool Add(Comment c, Comment p)
        {
            if (Pair == null)
            {
                Pair = new HashSet<Pair>();
            }
            return Pair.Add(CreatePair(c, p));
        }

        private static Pair CreatePair(Comment c, Comment p)
        {
            MiniComment cm = CreateMini(c);
            MiniComment pm = CreateMini(p);
            Pair tmp = new Pair {Copy = cm, Previous = pm};
            return tmp;
        }

        

        public int Count()
        {
            return Pair.Count;
        }
    }

//    public class PairComparer : IEqualityComparer
//    {
//        public bool Equals(object x, object y)
//        {
//            var p = x as MiniComment;
//            var c = y as MiniComment;
//            return p?.Equals(c) ?? false;
//        }
//
//        public int GetHashCode(object obj)
//        {
//            var m = obj as MiniComment;
//            return m?.GetHashCode() ?? obj.GetHashCode();
//        }
//    }

    public class Pair
    {
        [XmlElement("Original")]
        public MiniComment Previous { get; set; }
        [XmlElement("Copy")]
        public MiniComment Copy { get; set; }


    }

    
    public class PostSet
    {
        [XmlArray("Ids")]
        public HashSet<string>  Set { get; set; }

        [XmlAttribute("Count")] 
        public int Count { get; set; }

        [XmlElement("Subreddit")]
        public string Subreddit { get; set; }

        public bool Add(string s)
        {
            if(Set==null)Set=new HashSet<string>();
            if (Set.Add(s))
            {
                Count++;
                return true;
            }
            return false;
        }

        public bool Contains(string s)
        {
            if (Set == null)
            {
                Set=new HashSet<string>();
                return false;
            }
            return Set.Contains(s);
        }
    }*/
}
