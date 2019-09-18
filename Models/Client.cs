using DistripackAPI.Controllers.ApiModels;
using System;

namespace DistripackAPI.Models
{
    public class Client
    {
        public Client() { }

        //public ApplicationUser User { get; set; }

        // public String UserId { get; set; }

        public int Id { get; set; }

        public CheckingAccount CheckingAccount { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Nick { get; set; }

        public String Email { get; set; }

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
            FirstName = String.IsNullOrEmpty(apiClient.FirstName) ? FirstName : apiClient.FirstName;
            LastName = String.IsNullOrEmpty(apiClient.FirstName) ? LastName : apiClient.LastName;
            CelPhone = String.IsNullOrEmpty(apiClient.FirstName) ? CelPhone : apiClient.CelPhone;
            BusinessName = String.IsNullOrEmpty(apiClient.BusinessName) ? BusinessName : apiClient.BusinessName;
            FantasyName = String.IsNullOrEmpty(apiClient.FantasyName) ? FantasyName : apiClient.FantasyName;
            Cuit = String.IsNullOrEmpty(apiClient.Cuit) ? Cuit : apiClient.Cuit;
            Dni = String.IsNullOrEmpty(apiClient.Dni) ? Dni : apiClient.Dni;
            Location = String.IsNullOrEmpty(apiClient.Location) ? Location : apiClient.Location;
            Address = String.IsNullOrEmpty(apiClient.Address) ? Address : apiClient.Address;
            PostalCode = String.IsNullOrEmpty(apiClient.PostalCode) ? PostalCode : apiClient.PostalCode;
            Phone = String.IsNullOrEmpty(apiClient.Phone) ? Phone : apiClient.Phone;
        }

        public Payment AddPayment(CreatePayment payment)
        {
            if (CheckingAccount == null)
                throw new Exception($"the client: { Id } doesn't have a checking account");

            return CheckingAccount.AddPayment(payment);

        }

        public Transaction AddReceipt(Order order)
        {
            if (CheckingAccount == null)
                throw new Exception($"El cliente { Id } no tiene cuenta corriente");

            return CheckingAccount.AddReceipt(order);

        }

        public CheckingAccount AddAccount(int amount)
        {
            if (CheckingAccount != null)
                throw new Exception($"El cliente '{Id}' ya tiene una cuenta asociada");

            CheckingAccount = new CheckingAccount(Id, amount);
            return CheckingAccount;
        }

        public void SetInitialAmount(int amount)
        {
            if (CheckingAccount == null)
                throw new Exception($"El cliente '{Id}' no tiene una cuenta asociada");

            CheckingAccount.SetInitialAmount(amount);
        }
    }
}