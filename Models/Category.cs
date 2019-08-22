using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DistripackAPI.Models
{
    public class Category : Entity
    {
        public Category()
        {
            ProductCategories = new Collection<ProductCategory>();
        }

        public String Name { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        public bool IsCommercialType { get; set; }

        public IReadOnlyCollection<Product> Products
        {
            get { return this.ProductCategories.Select(x => x.Product).ToList(); }
        }
    }
}

