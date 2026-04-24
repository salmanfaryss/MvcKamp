using Bussiness.Concrete;
using Bussiness.FluentValidator;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectMVC.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult ReceiveMessageList()
        {
            var value = mm.TGetList();
            return View(value);
        }
        public ActionResult SenerMessageList()
        {
            var value = mm.TGetList();
            return View(value);
        }
        public ActionResult GetRecieverMessage(int id)
        {
            var value = mm.TGetByID(id);
            return View(value);
        }
        public ActionResult GetSenderMessage(int id)
        {
            var value = mm.TGetByID(id);
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateNewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNewMessage(Message p)
        {
          
            ValidationResult results = messageValidator.Validate(p);

            if (results.IsValid)
            {
                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.IsRead = false;
                mm.TUpdate(p);
                return RedirectToAction("SendBoxMessageList");
            }
            else
            {
                foreach (var itemt in results.Errors)
                {
                    ModelState.AddModelError(itemt.PropertyName, itemt.ErrorMessage);
                }
            }
            return View();
           
        }

    }
}