using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DistripackAPI.Models
{
    public class Product
    {
        public Product()
        {
            ProductCategories = new Collection<ProductCategory>();
            Skus = new Collection<Sku>();
        }

        public int Id { get; set; }

        public String Alias { get; set; }

        public String Nombre { get; set; }

        public ICollection<Sku> Skus { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }

        public IReadOnlyCollection<Category> Categorias
        {
            get { return this.ProductCategories.Select(x => x.Category).ToList(); }
        }
    }
}