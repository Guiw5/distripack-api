using System;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels
{
    public class UpdateClient : ApiModel
    {
        [Required]
        public String Email { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        [Required]
        public String CelPhone { get; set; }

        [Required]
        public String BusinessName { get; set; }

        [Required]
        public String FantasyName { get; set; }

        public String Cuit { get; set; }

        public String Dni { get; set; }

        [Required]
        public String Location { get; set; }

        [Required]
        public String Address { get; set; }

        public String Phone { get; set; }

        public String PostalCode { get; set; }

    }

}
