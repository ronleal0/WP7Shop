using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WP7Shop.Models.Entities
{
    public class Product : Entity
    {
        public virtual string Name { get; set; }
        public virtual Category Category { get; set; }
    }
}