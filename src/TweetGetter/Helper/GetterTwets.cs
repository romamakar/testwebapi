using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TweetGetter.Models;
using TweetGetter.Extensions;

namespace TweetGetter.Helper
{
    public class GetterTwets
    {
        public static async Task<List<Tweet>> GetProductAsync(string path, DateTime startDate, DateTime endDate)
        {
            List<Tweet> tweets = new List<Tweet>();
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{path}?startdate={startDate.ToUTC()}&enddate={endDate.ToUTC()}");
            if (response.IsSuccessStatusCode)
            {
                tweets = JsonConvert.DeserializeObject<List<Tweet>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception(response.ReasonPhrase + "/n" + response.RequestMessage);
            }

            if (tweets.Count == 100)
            {
                tweets.AddRange(await GetProductAsync(path, Convert.ToDateTime(tweets[99].stamp), endDate));
            }
            return tweets.Distinct(new TweetComparer()).ToList();
        }
    }
}
