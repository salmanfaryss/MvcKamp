using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart

        public ActionResult SweeatAlert()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> ct = new List<CategoryClass>();
            ct.Add(new CategoryClass()
            {
                CategoryName = "Yazilim",
                CategoryCount = 8
            });
            ct.Add(new CategoryClass()
            {
                CategoryName ="Tasarim",
                CategoryCount = 5,

            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Veritabanı",
                CategoryCount = 15,

            });
            ct.Add(new CategoryClass()
            {
                CategoryName = "Eski Konuları",
                CategoryCount = 10,
            });
            return ct;

            
        }
       
    }
}