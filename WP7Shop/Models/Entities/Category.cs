using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WP7Shop.Models.Entities
{
    public class Category : Entity
    {
        public virtual string Name { get; set; }
        public virtual IList<Product> Products { get; set; }
    }
}