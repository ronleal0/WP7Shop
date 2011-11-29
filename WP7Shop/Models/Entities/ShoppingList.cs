using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WP7Shop.Models.Entities
{
    public class ShoppingList : Entity
    {
        public virtual string Name { get; set; }
        public virtual ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}