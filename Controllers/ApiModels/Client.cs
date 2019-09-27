using System;

namespace DistripackAPI.Controllers.ApiModels
{
    public class Client : ApiModel
    {
        public int Id { get; set; }

        public String Nick { get; set; }

        public String Email { get; set; }

        public double? CurrentBalance { get; set; }

        public int? AccountId { get; set; }
    }


    public class FullClient : Client
    {

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String BusinessName { get; set; }

        public String FantasyName { get; set; }

        public String Cuit { get; set; }

        public String Dni { get; set; }

        public String Address { get; set; }

        public String Phone { get; set; }

        public String CelPhone { get; set; }

        public String Location { get; set; }

        public String PostalCode { get; set; }
    }
}
