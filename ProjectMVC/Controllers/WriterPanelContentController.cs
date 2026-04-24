using Bussiness.Concrete;
using DataAcces.EntityFramework;
using DataAccess.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        
        public ActionResult MyContent(string p)
        {
            Context c = new Context();
            p =(string) Session["WriterEmail"];
            var writerUserinfo = c.writers.Where(x => x.WriterEmail == p).Select(y => y.WriterID).FirstOrDefault();

            var value = cm.TGetListByWrier(writerUserinfo);
            return View(value);
        }
        public ActionResult MyContentByHeading(int id)
        {
            
            var value = cm.TGetContentListByHeading(id);
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateContent()
        {
            List<SelectListItem> writerValues = (from w in wm.TGetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = w.WriterName + " " + w.WriterSurname,
                                                     Value = w.WriterID.ToString()
                                                 }).ToList();
            List<SelectListItem> headingValue = (from h in hm.TGetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = h.HeadingName,
                                                     Value = h.HeadingID.ToString()
                                                 }).ToList();

            ViewBag.h = headingValue;
            ViewBag.w = writerValues;
            return View();
        }
        [HttpPost]
        public ActionResult CreateContent(Content p,string s)
        {
            Context c = new Context();
            

            s = (string)Session["WriterEmail"];
            var writerUserinfo = c.writers.Where(x => x.WriterEmail == s).Select(y => y.WriterID).FirstOrDefault();
            p.WriterID = writerUserinfo;
            p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.TInsert(p);
            
            return RedirectToAction("MyContent");
        }



    }
}