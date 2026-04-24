using Bussiness.Concrete;
using DataAcces.EntityFramework;
using DataAccess.Concrete;
using Entity.Concrete;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        Context c = new Context();

        [HttpGet]
        public ActionResult Profile(int id = 0)
        {
            string p =(string) Session["WriterEmail"];
            id = c.writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();
            var value = wm.TGetByID(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult Profile(Writer p)
        {
            wm.TUpdate(p);
            return RedirectToAction("WriterList");
        }
        public PartialViewResult WriterProfile()
        {
            string p = Session["WriterEmail"].ToString();
            var writerImage = c.writers.Where(x => x.WriterEmail == p).Select(y => y.WriterImage).FirstOrDefault();
            var writerName = c.writers.Where(x => x.WriterEmail == p).Select(y => y.WriterName + " " + y.WriterSurname).FirstOrDefault();
            ViewBag.Photo =writerImage ;
            ViewBag.WriterName =writerName ;


            return PartialView();
        }
        public ActionResult MyHeading(string p)
        {
           Context c = new Context();
            p = (string)Session["WriterEmail"];
            var writerUserinfo = c.writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();
            var value = hm.TGetListByWriter(writerUserinfo);

            return View(value);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> categoryValue =(from k in cm.TGetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = k.CategoryName,
                                                     Value =k.CategoryID.ToString(),
                                                 }).ToList();
            ViewBag.k = categoryValue;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            Context c =new Context();
           string s = Session["WriterEmail"].ToString();
            var writerUserinfo = c.writers.Where(x => x.WriterEmail == s).Select(y => y.WriterID).FirstOrDefault();
            p.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerUserinfo;
            p.Status = true;
            hm.TInsert(p);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult UpdateMyHeading(int id)
        {
            List<SelectListItem> categoryValue = (from k in cm.TGetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = k.CategoryName,
                                                      Value = k.CategoryID.ToString(),
                                                  }).ToList();
            ViewBag.k = categoryValue;
            var value = hm.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateMyHeading(Heading p)
        {
            Context c = new Context();
            string s = Session["WriterEmail"].ToString();
            var writerUserinfo = c.writers.Where(x => x.WriterEmail == s).Select(y => y.WriterID).FirstOrDefault();
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writerUserinfo;
            p.Status = true;
            hm.TUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteMyHeading(int id)
        {
           
            var value = hm.TGetById(id);
            hm.TDelete(value);
            return RedirectToAction("MyHeading");

        }
        public ActionResult AllHeading(int sayfa = 1)
        {
            var values = hm.TGetList().ToPagedList(sayfa,5);
            return View(values);
        }
    }
}