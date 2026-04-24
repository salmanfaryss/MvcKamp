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
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm =new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        ContentManager mm = new ContentManager(new EfContentDal());

        
        // GET: Heading

        public ActionResult HeadingReport()
        {
            var value = hm.TGetList();
            return View(value);
        }
        public ActionResult HeadingList()
        {
            var value = hm.TGetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateHeading()
        {
            List<SelectListItem>categoryValue =(from k in cm.TGetList()
                                                select new SelectListItem
                                                {
                                                    Text =k.CategoryName,
                                                    Value = k.CategoryID.ToString()
                                                }).ToList();   
            
            List<SelectListItem> writerValue =(from w in wm.TGetList()
                                               select new SelectListItem
                                               {
                                                   Text =w.WriterName + "" + w.WriterSurname,
                                                   Value = w.WriterID.ToString()
                                               }).ToList();
            ViewBag.k = categoryValue;
            ViewBag.w = writerValue;
            return View();
        }
        [HttpPost]
      
        public ActionResult CreateHeading(Heading p)
        {
            p.Date =DateTime.Parse( DateTime.Now.ToShortDateString());
            hm.TInsert(p);
            
            return RedirectToAction("HeadingList");
        }
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> categoryValue = (from k in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = k.CategoryName,
                                                      Value = k.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> writerValue = (from w in wm.TGetList()
                                                select new SelectListItem
                                                {
                                                    Text = w.WriterName + " " + w.WriterSurname,
                                                    Value = w.WriterID.ToString()
                                                }).ToList();

            ViewBag.k = categoryValue;
            ViewBag.w = writerValue;
            var value = hm.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading p)
        {

            p.Status = true;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.TUpdate(p);
            return RedirectToAction("HeadingList");
        }
        public ActionResult DeleteHeading(int id)
        {
            var value = hm.TGetById(id);
            hm.TDelete(value);
            return RedirectToAction("HeadingList");

        }


    }
}