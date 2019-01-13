using DistripackAPI.Controllers.ApiModels;
using System;

namespace DistripackAPI.Models
{
    public class Client : Entity
    {
        public Client() { }

        public Client(UpdateClient apiClient) : this(apiClient.FirstName, apiClient.LastName, apiClient.Email, apiClient.BusinessName, apiClient.FantasyName, apiClient.Cuit, apiClient.Dni, apiClient.Address, apiClient.Phone, apiClient.CelPhone, apiClient.Location, apiClient.PostalCode)
        {

        }

        public Client(string firstName, string lastName, string mail, string businessName, string fantasyName, string cuit, string dni, string address, string phone, string celPhone, string location, string postalCode)
        {
            Nick = fantasyName;
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
            BusinessName = businessName;
            FantasyName = fantasyName;
            Cuit = cuit;
            Dni = dni;
            Address = address;
            Phone = phone;
            CelPhone = celPhone;
            Location = location;
            PostalCode = postalCode;
        }

        //public ApplicationUser User { get; set; }

        // public String UserId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Nick { get; set; }

        public String Mail { get; set; }

        public String BusinessName { get; set; }

        public String FantasyName { get; set; }

        public String Cuit { get; set; }

        public String Dni { get; set; }

        public String Address { get; set; }

        public String Phone { get; set; }

        public String CelPhone { get; set; }

        public String Location { get; set; }

        public String PostalCode { get; set; }

        internal void Update(UpdateClient apiClient)
        {
            FirstName = apiClient.FirstName;
            LastName = apiClient.LastName;
            CelPhone = apiClient.CelPhone;
            BusinessName = apiClient.BusinessName;
            FantasyName = apiClient.FantasyName;
            Cuit = apiClient.Cuit;
            Dni = apiClient.Dni;
            Location = apiClient.Location;
            Address = apiClient.Address;
            PostalCode = apiClient.PostalCode;
            Phone = apiClient.Phone;
        }

    }
}