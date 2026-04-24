using Bussiness.Concrete;
using Bussiness.FluentValidator;
using DataAcces.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectMVC.Controllers
{
    public class CategoryController : Controller
    {
       
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        // GET: Category

        [Authorize(Roles="B")]
        public ActionResult CategoryList()
        {

            var value = cm.TGetList();
            return View(value);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category p)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);

            if (results.IsValid)
            {
                cm.TInsert(p);
                p.CategoryStatus = false;
                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach(var itemt in results.Errors)
                {
                    ModelState.AddModelError(itemt.PropertyName,itemt.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = cm.TGetById(id);
            cm.TDelete(value);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value =cm.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            cm.TUpdate(p);
            return RedirectToAction("CategoryList");
        }
    }
}