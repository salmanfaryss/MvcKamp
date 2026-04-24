using Bussiness.Concrete;
using DataAcces.EntityFramework;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());
        Context c = new Context();
        public ActionResult Headings()
        {

            var value = hm.TGetList();

            return View(value);
        }
        public PartialViewResult ContentList(int id =0)
        {
            var value = cm.TGetContentListByHeading(id);
            return PartialView(value);
        }
    }
}