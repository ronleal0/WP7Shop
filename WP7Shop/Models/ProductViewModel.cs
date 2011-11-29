using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WP7Shop.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WP7Shop.Models
{
    public class ProductViewModel
    {
        public ProductViewModel()
        { 
        }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;

            if (product.Category != null)
            {
                CategoryId = product.Category.Id;
            }
            

        }

        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int? CategoryId { get; set; }
        public List<SelectListItem> Categories { get; set; }

        internal void UpdateEntity(Product product, string userName, Category category)
        {
            product.Name = Name;
            product.UserName = userName;
            product.Category = category;
        }
    }
}