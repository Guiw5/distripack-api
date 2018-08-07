using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.Resources
{
    public class Product
    {
        public Product()
        {
            CategoriesId = new Collection<int>();
        }

        [Required]
        public int Id { get; set; }

        public int Sku { get; set; }

        public String Code => "COD" + $"{Id + Sku,10:D5}";

        public String Nick { get; set; }

        public String Description { get; set; }

        public String Brand { get; set; }

        public String Color { get; set; }

        public int Quantity { get; set; }

        public Double Price { get; set; }

        public String Capacity { get; set; }

        public String Measures { get; set; }

        public String Material { get; set; }

        //public DateTime CreationDate { get; set; }

        //public DateTime? DeletionDate { get; set; }

        //public DateTime? LastUpdate { get; set; }

        public ICollection<int> CategoriesId { get; set; }

    }
}
