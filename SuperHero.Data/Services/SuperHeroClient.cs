using Newtonsoft.Json;
using SuperHero.Cache;
using SuperHero.Common;
using SuperHero.Data.Models;
using System.Configuration;
using System.Threading.Tasks;

namespace SuperHero.Data.Services
{
    public class SuperHeroClient
    {
        _HttpClient client;
        CacheStrigsStack cache;

        public SuperHeroClient()
        {
            this.client = new _HttpClient(ConfigurationManager.AppSettings["SuperHeroAPIBaseUrl"]);
            this.cache = new CacheStrigsStack();
        }

        public async Task<SearchResultModel> Search(string name)
        {
            SearchResultModel result;
            string cacheKey = $"search-{name}";

            if (this.cache.IsKeyExists(cacheKey))
            {
                var dbCacheItem = this.cache.GetStrings(cacheKey);
                result = JsonConvert.DeserializeObject<SearchResultModel>(dbCacheItem);
            }
            else
            {
                result = await this.client.GetRequest<SearchResultModel>($"search/{name}");
                if (result.Response != null && result.Response.Equals(Constants.SUPER_HERO_API_SUCCESS_RESPONSE))
                {
                    this.cache.SetStrings(cacheKey, JsonConvert.SerializeObject(result));
                    foreach (var profile in result.Results)
                    {
                        this.cache.SetStrings($"profile-{profile.Id}", JsonConvert.SerializeObject(profile));
                    }
                }
            }

            return result;
        }

        public async Task<ProfileResultModel> GetProfile(int characterId)
        {
            ProfileResultModel result;
            string cacheKey = $"profile-{characterId}";

            if (this.cache.IsKeyExists(cacheKey))
            {
                var dbCacheItem = this.cache.GetStrings($"profile-{characterId}");
                result = JsonConvert.DeserializeObject<ProfileResultModel>(dbCacheItem);
                result.Response = Constants.SUPER_HERO_API_SUCCESS_RESPONSE;
            }
            else
            {
                result = await this.client.GetRequest<ProfileResultModel>($"{characterId}");
                if (result.Response.Equals(Constants.SUPER_HERO_API_SUCCESS_RESPONSE))
                {
                    this.cache.SetStrings($"profile-{characterId}", JsonConvert.SerializeObject(result));
                }
            }

            return result;
        }

    }
}