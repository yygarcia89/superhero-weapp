using StackExchange.Redis;
using SuperHero.Common.Helpers;
using System;
using System.Configuration;

namespace SuperHero.Cache
{
    public class CacheStrigsStack
    {
        IDatabase db;

        public CacheStrigsStack()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisEndpoint"]);
            this.db = redis.GetDatabase();
        }

        public CacheStrigsStack(string redisEndpoint)
        {
            ConnectionMultiplexer _redis = ConnectionMultiplexer.Connect(redisEndpoint);
            this.db = _redis.GetDatabase();
        }

        public bool IsKeyExists(string key) => this.db.KeyExists(key);

        public void SetStrings(string key, string value, int minutesTimeout = 1440) =>
            this.db.StringSet(key, value.CompressString(), expiry: new TimeSpan(0, minutesTimeout, 0));

        public string GetStrings(string key) => this.db.StringGet(key).ToString().DecompressString();
    }
}
