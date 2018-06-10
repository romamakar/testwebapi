using System;
using TweetGetter.Extensions;
using Xunit;

namespace TweetGetter.UnitTests
{
    public class ExtensionTests
    {
        [Fact]
        public void IsDateTimeConvertedToUtcCorrect()
        {
            DateTime dt = new DateTime(2000, 11, 12, 9, 10, 50);
            string expected = "2000-11-12T09:10";
            var dtstr = dt.ToUTCView();
            Assert.IsType<string>(dtstr);
            Assert.Equal(expected, dtstr);
        }

        [Fact]
        public void IsDateTimeConvertedToUtcNotCorrect()
        {
            DateTime dt = new DateTime(2000, 11, 12, 9, 10, 50);
            string expected = "2001-11-12T09:10";
            var dtstr = dt.ToUTCView();
            Assert.IsType<string>(dtstr);
            Assert.NotEqual(expected, dtstr);
        }
        [Fact]
        public void IsDateTimeConvertedToUtcFullCorrect()
        {
            DateTime dt = new DateTime(2000, 11, 12, 9, 10, 50);
            string expected = "2000-11-12T09:10:50.000Z"; 
            var dtstr = dt.ToUTC();
            Assert.IsType<string>(dtstr);
            Assert.Equal(expected, dtstr);
        }

        [Fact]
        public void IsDateTimeConvertedToUtcFullNotCorrect()
        {
            DateTime dt = new DateTime(2000, 11, 12, 9, 10, 50);
            string expected = "2001-11-12T09:10:50.001Z"; ;
            var dtstr = dt.ToUTC();
            Assert.IsType<string>(dtstr);
            Assert.NotEqual(expected, dtstr);
        }
    }
}
