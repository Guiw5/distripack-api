using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Controllers.Resources
{
    public class Category
    {
        public Category() => Products = new Collection<Product>();

        public byte Id { get; set; }

        public String Name { get; set; }

        public ICollection<Product> Products { get; set; }

        public bool IsCommercialType { get; set; }
    }
}