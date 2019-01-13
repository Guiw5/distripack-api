using System;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels
{
    public class CreateClient : ApiModel
    {
        [Required]
        public String Nick { get; set; }

        [Required]
        public String Mail { get; set; }

        public String Cuit { get; set; }
    }

}
