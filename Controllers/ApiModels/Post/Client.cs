using System;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels.Post
{
    public class Client
    {
        public String Name { get; set; }

        [Required]
        public String Nick { get; set; }

        [Required]
        public String Mail { get; set; }

        public String Cuit { get; set; }
    }
}
