using System;

namespace DistripackAPI.Controllers.ApiModels
{
    public class CheckingAccount : ApiModel
    {
        public int Id { get; set; }

        public Client Client { get; set; }

        public double CurrentBalance { get; set; }

        public DateTime UpdatedAt { get; set; }

        public double InitialAmount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}