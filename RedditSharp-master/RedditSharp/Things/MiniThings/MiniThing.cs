using System;
using System.ComponentModel.Design;
using RedditSharp.Things.VotableThings;
using RedditSharp.Utils;

namespace RedditSharp.Things.MiniThings
{
    public class MiniThing:IMini,IEquatable<VotableThing>
    {
        public MiniThing(VotableThing t)
        {
            Id= t?.Id??"unkown";
            Upvotes = t?.Upvotes??-1;
            Created = t?.Created??DateTime.MinValue;
            ShortLink = t?.Shortlink??"http://redd.it/"+Id;
        }

        public int Upvotes { get; set; }
        public string Id { get; set; }
        public virtual string ShortLink { get; }
        public DateTime Created { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is MiniThing)) return false;
            return Equals((MiniThing) obj);
        }

        protected bool Equals(MiniThing other)
        {
            bool eq = string.Equals(ShortLink, other.ShortLink,StringComparison.InvariantCultureIgnoreCase);
            Logger.WriteLine(eq ? $"{this} == {other}" : $"{this} != {other}");
            return eq;
        }

        public override int GetHashCode()
        {
            return ShortLink?.GetHashCode() ?? 0;
        }

        public bool Equals(VotableThing other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Upvotes}+ created on {Created}. {ShortLink}";
        }
    }
}