using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using WebApplication6.Models.DefaultModel;

namespace WebApplication6.Controllers
{
    public class JayRideController : Controller
    {
        // GET: JayRide
        public ActionResult Index()
        {
            return View(new JayRideModel());
        }
    }
}