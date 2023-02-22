using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication6.Areas.HelpPage.Models;
using WebApplication6.Models;
using WebApplication6.Models.DefaultModel;

namespace WebApplication6.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View(new DefaultModel());
        }
        //public ActionResult Api(string apiId)
        //{
        //    DefaultModel dm = new DefaultModel();
        //    if (!String.IsNullOrEmpty(apiId))
        //    {
               

        //        //if (apiModel != null)
        //        //{
        //        //    return View(apiModel);
        //        //}
        //        {
        //            return View(dm);
        //        }


        //    }

        //    return View(dm);

        //}
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Default2/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Default2
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Default2/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Default2/5
        public void Delete(int id)
        {
        }
    }
}