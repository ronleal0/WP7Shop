using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WP7Shop.Models.Entities;

namespace WP7Shop.Models
{
    public class ShoppingListViewModel
    {
        public ShoppingListViewModel() { }

        public ShoppingListViewModel(ShoppingList shoppingList)
        {
            Id = shoppingList.Id;
            Name = shoppingList.Name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }

        internal void UpdateEntity(ShoppingList shoppingList, string userName)
        {
            shoppingList.Name = Name;
            shoppingList.UserName = userName;
        }
    }
}