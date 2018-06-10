using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace TweetGetter.UnitTests.stubs
{
    public class Config : IConfiguration
    {
        private Dictionary<string, IConfigurationSection> configs = new Dictionary<string, IConfigurationSection>();
        public Config(Section section)
        {
            configs.Add("TweetConfiguration", section);
        }
        public string this[string key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            configs.TryGetValue(key, out IConfigurationSection section);
            return section;
        }
    }
    public class Section : IConfigurationSection
    {
        public string this[string key] { get => "testpath"; set => throw new NotImplementedException(); }

        public string Key => throw new NotImplementedException();

        public string Path => throw new NotImplementedException();

        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }
    }
}
