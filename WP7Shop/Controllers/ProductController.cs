using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WP7Shop.Models;
using WP7Shop.Models.Entities;

namespace WP7Shop.Controllers
{
    public class ProductController : SessionController
    {
        public ActionResult Index()
        {
            var products = Session.QueryOver<Product>()
                .Where(x => x.UserName == HttpContext.User.Identity.Name)
                .List<Product>();

            return View(products);
        }

        public ActionResult Create()
        {
            var model = new ProductViewModel();

            PopulateSelectLists(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(ProductViewModel model)
        {
            var product = new Product();
            var category = Session.Get<Category>(model.CategoryId);

            model.UpdateEntity(product, HttpContext.User.Identity.Name, category);

            Session.Save(product);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var product = Session.Get<Product>(id);
            if (product == null) throw new Exception("Product not found");

            var model = new ProductViewModel(product);

            PopulateSelectLists(model);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel model)
        {
            var product = Session.Get<Product>(model.Id);
            var category = Session.Get<Category>(model.CategoryId);

            if (product == null) throw new Exception("Product is null");

            model.UpdateEntity(product, HttpContext.User.Identity.Name, category);

            Session.Save(product);

            return RedirectToAction("Index");
        }


        public ActionResult Delete()
        {

            return View();
        }

        public void PopulateSelectLists(ProductViewModel model)
        {
            var categories = Session.QueryOver<Category>()
                .Where(x => x.UserName == HttpContext.User.Identity.Name)
                .List<Category>();

            var categoriesSelectListItems = new List<SelectListItem>();

            foreach (var item in categories)
            {
                var SelectItem = new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                };


                categoriesSelectListItems.Add(SelectItem);
            }
            model.Categories = categoriesSelectListItems;
        }
    }
}
