using Newtonsoft.Json;
using SuperHero.Common;
using SuperHero.Data.Models;
using System.Configuration;
using System.Threading.Tasks;

namespace SuperHero.Data.Services
{
    public class SuperHeroClient
    {
        _HttpClient client;

        public SuperHeroClient()
        {
            this.client = new _HttpClient(ConfigurationManager.AppSettings["SuperHeroAPIBaseUrl"]);
        }

        public async Task<SearchResultModel> Search(string name)
        {
            SearchResultModel result = await this.client.GetRequest<SearchResultModel>($"search/{name}");

            return result;
        }

        public async Task<ProfileResultModel> GetProfile(int characterId)
        {
            ProfileResultModel result = await this.client.GetRequest<ProfileResultModel>($"{characterId}");

            return result;
        }

    }
}