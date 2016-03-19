namespace RedditSharp.Things.MiniThings
{
    public interface IPost
    {
        string Author { get; set; }
        string Subreddit { get; set; }
    }
}