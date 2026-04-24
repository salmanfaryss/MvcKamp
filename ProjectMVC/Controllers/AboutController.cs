using Bussiness.Concrete;
using DataAcces.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EfAboutDal());

       
        public ActionResult AboutList()
        {
            var values = am.TGetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(About p)
        {
            am.TInsert(p);
            return RedirectToAction("AboutList");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}