using System;

namespace DistripackAPI.Models
{
    public class Client : Entity
    {
        //public ApplicationUser User { get; set; }

        // public String UserId { get; set; }

        public String Name { get; set; }

        public String Nick { get; set; }

        public String Mail { get; set; }

        public String BusinessName { get; set; }

        public String Cuit { get; set; }

        public String Address { get; set; }

        public String Phone { get; set; }

        public String CelPhone { get; set; }

        public String Location { get; set; }

        public String PostalCode { get; set; }
    }
}