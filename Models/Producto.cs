using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DistripackAPI.Models
{
    public class Producto
    {
        public Producto()
        {
            ProductoCategorias = new Collection<ProductoCategoria>();
        }

        public int Id { get; set; }

        public int Sku { get; set; }

        public String Alias { get; set; }

        public String Nombre { get; set; }

        public String Codigo { get; set; }

        public String AliasSku { get; set; }

        public String Descripcion { get; set; }

        public String Marca { get; set; }

        public String Color { get; set; }

        public int Cantidad { get; set; }

        public Double Precio { get; set; }

        public String Capacidad { get; set; }

        public ICollection<ProductoCategoria> ProductoCategorias { get; set; }

        public String Medidas { get; set; }

        public String Material { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaEliminado { get; set; }

        public DateTime? FechaModificacion { get; set; }

        public IReadOnlyCollection<Categoria> Categorias
        {
            get { return this.ProductoCategorias.Select(x => x.Categoria).ToList(); }
        }
    }
}