using System;
using System.Net.Http;
using System.Threading.Tasks;
using TweetGetter.Helper;
using Xunit;

namespace TweetGetter.UnitTests
{
    public class GetterTests
    {
        [Fact]
        public async Task IsThrowExceptionOnIncorrectUrl()
        {
            await Assert.ThrowsAsync<HttpRequestException>(() => GetterTwets.GetProductAsync("http://gettest", new DateTime(), new DateTime()));
        }
    }
}
