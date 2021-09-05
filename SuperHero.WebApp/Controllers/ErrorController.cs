using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.WebApp.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Index()
        {
            //Response.StatusCode = 404;

            return View();
        }
        public ActionResult NotFound()
        {
            //Response.StatusCode = 404;

            return View();
        }


    }
}