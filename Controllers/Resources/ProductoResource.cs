using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Controllers.Resources
{
    public class ProductoResource
    {
        public ProductoResource()
        {
            CategoriasId = new Collection<int>();
        }

        public int Id { get; set; }

        public int Sku { get; set; }

        public String Codigo => "COD" + $"{Id + Sku,10:D5}";

        public String Alias { get; set; }

        public String Descripcion { get; set; }

        public String Marca { get; set; }

        public String Color { get; set; }

        public int Cantidad { get; set; }

        public Double Precio { get; set; }

        public String Capacidad { get; set; }

        public String Medidas { get; set; }

        public String Material { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public ICollection<int> CategoriasId { get; set; }

    }
}
