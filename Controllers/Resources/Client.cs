using System;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.Resources
{
    public class Client
    {
        [Required]
        public String Nick { get; set; }

        [Required]
        public String Email { get; set; }

        //public String Nombre { get; set; }

        //public String RazonSocial { get; set; }        

        //public String Cuit { get; set; }

        //public String Dni { get; set; }

        //public String UsuarioId { get; set; }

        //public String Telefono { get; set; }

        //public String Direcion { get; set; }

    }
}
