using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WP7Shop.Models.Entities;
using WP7Shop.Models;

namespace WP7Shop.Controllers
{
    public class ShoppingListController : SessionController
    {
        public ActionResult Index()
        {
            var shoppingLists = Session.QueryOver<ShoppingList>()
                .Where(x => x.UserName == HttpContext.User.Identity.Name)
                .List<ShoppingList>();

            return View(shoppingLists);
        }

        public ActionResult Create()
        {
            var model = new ShoppingListViewModel();

            return View(model);
        } 

        [HttpPost]
        public ActionResult Create(ShoppingListViewModel model)
        {
            var shoppingList = new ShoppingList();

            model.UpdateEntity(shoppingList, HttpContext.User.Identity.Name);

            Session.Save(shoppingList);

            return RedirectToAction("Index");
        }
        
        //
        // GET: /ShoppingList/Edit/5
 
        public ActionResult Edit(int id)
        {
            var shoppingList = Session.Get<ShoppingList>(id);
            if (shoppingList == null) throw new Exception("Shopping list not found");

            var model = new ShoppingListViewModel(shoppingList);

            return View(model);
        }

        //
        // POST: /ShoppingList/Edit/5

        [HttpPost]
        public ActionResult Edit(ShoppingListViewModel model)
        {
            var shoppingList = Session.Get<ShoppingList>(model.Id);
            if (shoppingList == null) throw new Exception("Shopping list not found");

            model.UpdateEntity(shoppingList, HttpContext.User.Identity.Name);

            Session.Save(shoppingList);

            return RedirectToAction("Index");
        }

        //
        // GET: /ShoppingList/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /ShoppingList/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
