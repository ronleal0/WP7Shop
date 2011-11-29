using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WP7Shop.Models.Entities;

namespace WP7Shop.Models
{
    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
        }

        public CategoryViewModel(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }
        public int? Id { get; set; }
        public string Name { get; set; }

        internal void UpdateEntity(Category category, string userName)
        {
            category.Name = Name;
            category.UserName = userName;
        }
    }
}