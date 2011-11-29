using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WP7Shop.Models;
using WP7Shop.Models.Entities;

namespace WP7Shop.Controllers
{
    public class CategoryController : SessionController
    {
        //
        // GET: /Category/

        public ActionResult Index()
        {
            var categories = Session.QueryOver<Category>()
                .Where(x => x.UserName == HttpContext.User.Identity.Name)
                .List<Category>();

            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryViewModel model)
        {
            var category = new Category();

            model.UpdateEntity(category, HttpContext.User.Identity.Name);

            Session.Save(category);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var category = Session.Get<Category>(id);
            if (category == null) throw new Exception("Category not found");

            return View(new CategoryViewModel(category));
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel model)
        {
            var category = Session.Get<Category>(model.Id);

            if (category == null) throw new Exception("Category is null");

            model.UpdateEntity(category, HttpContext.User.Identity.Name);

            Session.Save(category);

            return RedirectToAction("Index");
        }
    }
}
