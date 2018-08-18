using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Controllers.ApiModels.Get
{
    public class Product
    {
        public Product()
        {
            CategoriesId = new Collection<int>();
        }

        public int Id { get; set; }

        public String Nick { get; set; }

        public String Name { get; set; }

        public ICollection<Sku> Skus { get; set; }

        public ICollection<int> CategoriesId { get; set; }
    }
}
