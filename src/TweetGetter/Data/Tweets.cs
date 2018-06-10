using System.Collections.Generic;
using TweetGetter.Models;

namespace TweetGetter.Data
{
    public class Tweets
    {
        public static List<Tweet> ListAllTweets { get; set; } = new List<Tweet>();
    }
}
