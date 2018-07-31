using DistriPack.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DistripackAPI.Models
{
    public class Categoria
    {
        public Categoria()
        {
            ProductoCategorias = new Collection<ProductoCategoria>();
        }

        public byte Id { get; set; }

        public String Nombre { get; set; }

        public ICollection<ProductoCategoria> ProductoCategorias { get; set; }

        public bool EsRubro { get; set; }
    }
}

