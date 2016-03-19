using System.Collections.Generic;
using System.Linq;
using RedditSharp.Things.VotableThings;

namespace RedditSharp.RedditBot.Repost
{
    public class Table
    {
        public List<Repost> Posts;

        public List<Post> FilteredPosts => Posts.Where(x=>x.IsValid).Select(x=>x.Post).Where(x=>x.Valid).ToList();

        public bool Any => FilteredPosts.Any();

        public Table(string innerText)
        {
            var lines =
                innerText.Split('\n').Where(
                    x =>
                        x.Contains('|') && !x.Contains("title | points | age ") &&
                        !x.Contains(":--|:--|:--|:--|:--")).ToList();
            Posts = lines.Select(x => new Repost(x)).ToList();
        }

        public override string ToString()
        {
            return string.Join("\n", Posts.Select(x=>x.ToString()));
        }
    }

   
}