using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UST_Careers.Domain.Abstract;

namespace UST_Careers.WebUI.Controllers
{
    public class LocationController : Controller
    {
        private ILocationRepository repository;

        public LocationController(ILocationRepository locationRepostiory)
        {
            repository = locationRepostiory;
        }
        public ActionResult Index()
        {
            return View(repository.Locations);
        }
    }
}