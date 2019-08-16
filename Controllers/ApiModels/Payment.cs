using System;

namespace DistripackAPI.Controllers.ApiModels
{
    public class Payment : Transaction
    {
        public DateTime PaymentAt { get; set; }
        public string Method { get; set; }
    }
}