using Bussiness.Concrete;
using DataAcces.EntityFramework;
using DataAccess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();

            var adminUserinfo = c.admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            
            if(adminUserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserinfo.AdminUserName,false);
                Session["AdminUserName"] =adminUserinfo.AdminUserName;
                return RedirectToAction("CategoryList", "Category");
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c =new Context();
            //var writerUserinfo = c.writers.FirstOrDefault(x => x.WriterEmail == p.WriterEmail && x.WriterPassword == p.WriterPassword);
            var writerUserinfo = wlm.TGetWriter(p.WriterEmail, p.WriterPassword);
            if (writerUserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserinfo.WriterEmail, false);
                Session["WriterEmail"] =writerUserinfo.WriterEmail;
               return RedirectToAction("MyHeading", "WriterPanel");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
          
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("WriterLogin","Login");
        }
    }
}