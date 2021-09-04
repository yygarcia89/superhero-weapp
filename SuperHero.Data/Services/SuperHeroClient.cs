using SuperHero.Data.Models;
using System.Threading.Tasks;

namespace SuperHero.Data.Services
{
    public class SuperHeroClient
    {
        _HttpClient client;

        public SuperHeroClient()
        {
            this.client = new _HttpClient();
        }

        public Task<SearchResultModel> Search(string name) =>
            this.client.GetRequest<SearchResultModel>($"https://www.superheroapi.com/api.php/4825472240813864/search/{name}");

        public Task<ProfileModel> GetProfile(int characterId) =>
            this.client.GetRequest<ProfileModel>($"https://superheroapi.com/api/4825472240813864/{characterId}");
    }
}
