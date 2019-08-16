using System;

namespace DistripackAPI.Controllers.ApiModels
{
    public class CheckingAccount
    {
        public int Id { get; set; }
        public double CurrentBalance { get; set; }
        public int ClientId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}