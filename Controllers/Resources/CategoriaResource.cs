using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Controllers.Resources
{
    public class CategoriaResource
    {
        public CategoriaResource() => Productos = new Collection<ProductoResource>();

        public byte Id { get; set; }
        public String Nombre { get; set; }

        public ICollection<ProductoResource> Productos { get; set; }

        public bool EsRubro { get; set; }
    }
}