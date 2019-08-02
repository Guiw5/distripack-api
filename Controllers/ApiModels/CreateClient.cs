using System;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels
{
    public class CreateClient : ApiModel
    {
        [Required]
        public String Email { get; set; }
    }

    public class CreateThinClient : CreateClient
    {
        [Required]
        public String Nick { get; set; }

        public String Cuit { get; set; }
    }

    public class CreateWebClient : CreateClient
    {
        [Required]
        public String FirstName { get; set; }

        [Required]
        public String LastName { get; set; }
    }

}
