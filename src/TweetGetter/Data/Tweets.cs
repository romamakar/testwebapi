using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TweetGetter.Models;

namespace TweetGetter.Data
{
    public class Tweets
    {
        public static List<Tweet> ListAllTweets { get; set; } = new List<Tweet>();
    }
}
