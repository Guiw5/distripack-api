using System;

namespace DistripackAPI.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        //public ApplicationUser User { get; set; }

        // public String UserId { get; set; }

        public String Nombre { get; set; }

        public String Alias { get; set; }

        public String Mail { get; set; }

        public String RazonSocial { get; set; }

        public String Cuit { get; set; }

        public String Direccion { get; set; }

        public String TelefonoFijo { get; set; }

        public String Celular { get; set; }

        public String Localidad { get; set; }

        public String CodigoPostal { get; set; }
    }
}