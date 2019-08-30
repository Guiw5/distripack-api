using System;

namespace DistripackAPI.Controllers.ApiModels
{
    public class Account : ApiModel
    {
        public Client Client { get; set; }

        public double CurrentBalance { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}