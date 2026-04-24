using Bussiness.Concrete;
using Bussiness.FluentValidator;
using DataAccess.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        Context c = new Context();
        public ActionResult MyInbox()
        {
           string p = (string)Session["WriterEmail"];

            var writeruserinfo = c.writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID);
            var value = mm.TGetListInbox(p);
            return View(value);
        }
        public ActionResult MySendBox()
        {
            string p = Session["WriterEmail"].ToString();
            var value = mm.TGetListSendBox(p);
            return View(value);
        }
        public ActionResult TrashMessage()
        {
            var value = mm.TGetTrashList();
            return View(value);
        }
        public ActionResult Spam()
        {
            string user = "ali.yildiz@mail.com";

            var values = mm.TGetSpamList(user);
            return View(values);
           
        }
        public ActionResult ChangeToSpam(Message p)
        {
            mm.ChangeToSpam(p);
            return RedirectToAction("MyInbox");
        }
        public ActionResult MoveToSpam(int id)
        {
            var value = mm.TGetByID(id);
            mm.ChangeToSpam(value);

            return RedirectToAction("Inbox");
        }
        public ActionResult DeleteMessage(int id)
        {
            var value = mm.TGetByID(id);
            mm.TDelete(value);
            return RedirectToAction("MyInbox");
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
          
            var value = mm.TGetByID(id);
            if (!value.IsRead)
            {
                mm.ChangeToTrue(value);
            }
            return View(value);
        }
        public ActionResult GetSendMessageDetails(int id)
        {
          
            var value = mm.TGetByID(id);
            if (!value.IsRead)
            {
                mm.ChangeToTrue(value);
            }
            return View(value);
        }
        [HttpGet]
        public ActionResult MyNewMessage()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult MyNewMessage(Message p)
        {
            try
            {
                ValidationResult results = messageValidator.Validate(p);
                string sender = (string)Session["WriterEmail"];
                var writeruserinfo = c.writers.Where(x => x.WriterEmail == sender).Select(y => y.WriterID);

                if (results.IsValid)
                {
                    p.Sender = sender;
                    p.Date = DateTime.Now;
                    p.IsRead = false;
                    p.Content = Regex.Replace(p.Content, "<.*?>", "");

                    mm.TInsert(p);

                    return RedirectToAction("MySendBox");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError("", item.ErrorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("HATA: " + ex.Message);
            }
            return View();
           
        }
        public PartialViewResult WriterPanelMessageMenu()
        {
            string p = (string)Session["WriterEmail"];
            var writerReciverEmail = c.messages.Where(x => x.Receiver == p ).Select(y => y.Receiver);
            var writerSenderEmail = c.messages.Where(x => x.Sender == p).Select(y => y.Sender);
            ViewBag.MySenderMessageCount = writerSenderEmail.Count();
            ViewBag.MyMessageCount = writerReciverEmail.Count();

            ViewBag.Cop = c.messages.Where(x => x.IsTrash == true).Count();
            ViewBag.SpamCount = c.messages.Where(x => x.IsSpam == true).Count();
          
            return PartialView();
        }
    }
}