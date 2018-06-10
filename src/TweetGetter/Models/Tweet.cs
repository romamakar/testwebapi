using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TweetGetter.Models
{
    public class Tweet
    {
        public string id { get; set; }
        public DateTime stamp { get; set; }
        public string text { get; set; }
        
    }

    public class TweetComparer : IEqualityComparer<Tweet>
    {
        public bool Equals(Tweet x, Tweet y)
        {
            return x.text == y.text;
        }

        public int GetHashCode(Tweet obj)
        {
            return obj.text.GetHashCode();
        }
    }

}
