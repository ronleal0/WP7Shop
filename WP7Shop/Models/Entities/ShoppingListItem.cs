using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WP7Shop.Models.Entities
{
    public class ShoppingListItem : Entity  
    {
        public virtual Product Product { get; set; }
        public virtual bool IsInCart { get; set; }
    }
}