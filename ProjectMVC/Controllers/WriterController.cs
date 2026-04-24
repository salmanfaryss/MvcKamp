using Bussiness.Concrete;
using Bussiness.FluentValidator;
using DataAcces.EntityFramework;
using Entity.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterDal());
        // GET: Writer
        public ActionResult WriterList()
        {
            var value = wm.TGetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateWriter(Writer p)
        {
            WriterValidator writerValidator = new WriterValidator();
            ValidationResult results = writerValidator.Validate(p);

            if (results.IsValid)
            {
                wm.TInsert(p);
              
                return RedirectToAction("WriterList");
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
        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var value = wm.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer p)
        {
            wm.TUpdate(p);
            return RedirectToAction("WriterList");
        }
    }
}