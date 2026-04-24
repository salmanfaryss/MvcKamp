using Bussiness.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var value = am.TGetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admin p)
        {
            am.TInsert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = am.TGetAdmin(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {
           am.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}