using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Controllers.Resources
{
    public class CategoryResource
    {
        public CategoryResource() => Products = new Collection<ProductResource>();

        public byte Id { get; set; }

        public String Name { get; set; }

        public ICollection<ProductResource> Products { get; set; }

        public bool IsCommercialType { get; set; }
    }
}