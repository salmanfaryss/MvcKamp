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
    //[AllowAnonymous]
    public class ContactController : Controller
    {
        // GET: Contact
        Context c = new Context();
       
        ContactManager cm = new ContactManager(new EfContactDal());
       
        public ActionResult ContactList()
        {
            var value = cm.TGetList();
            return View(value);
        }
        public ActionResult GetContactDetail(int id)
        {
            var value = cm.TGetByID(id);
            return View(value);
        }

        public PartialViewResult ContactMenu()
        {
            ViewBag.ContactCount = c.contacts.Count();
            ViewBag.ReceiverMessageCount = c.messages.Select(x => x.Receiver).Count();
            ViewBag.SenderMessageCount = c.messages.Select(x => x.Sender).Count();
            return PartialView();
        }
    }
}