using StackExchange.Redis;
using SuperHero.Common.Helpers;
using System;
using System.Configuration;

namespace SuperHero.Cache
{
    public class CacheStrigsStack
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisEndpoint"]);
        IDatabase db;

        TimeSpan EXPIRATION_TIMEOUT = new TimeSpan(23, 59, 59);

        public CacheStrigsStack()
        {
            this.db = redis.GetDatabase();
        }

        public bool IsKeyExists(string key) => this.db.KeyExists(key);

        public void SetStrings(string key, string value) => this.db.StringSet(key, value.CompressString(), expiry: EXPIRATION_TIMEOUT);

        public string GetStrings(string key) => this.db.StringGet(key).ToString().DecompressString();
    }
}
