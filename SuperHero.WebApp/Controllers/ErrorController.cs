﻿using System.Web.Mvc;

namespace SuperHero.WebApp.Controllers
{
    public class ErrorController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NotFound()
        {
            return View();
        }
    }
}