using SuperHero.Common;
using SuperHero.Data.Models;
using SuperHero.Data.Services;
using SuperHero.WebApp.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private SuperHeroClient _client = new SuperHeroClient();

        public async Task<ActionResult> Index(string q)
        {
            SearchResultModel model = new SearchResultModel();
            if (!string.IsNullOrEmpty(q))
            {
                model = await _client.Search(q);
            }
            return View(model);
        }

        [Route("/character/{id}")]
        public async Task<ActionResult> Character(int Id)
        {            
            var model = await _client.GetProfile(Id);
            if (model.Response.Equals(Constants.SUPER_HERO_API_ERROR_RESPONSE, 
                System.StringComparison.InvariantCultureIgnoreCase))
            {
                throw new HttpException(404, "HTTP/1.1 404 Not Found");
            }
            
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(SearchRequestModel model)
        {
            return RedirectToAction(nameof(Index), new { q = model.Query });
        }
    }
}