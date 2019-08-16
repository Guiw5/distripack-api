using DistripackAPI.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace DistripackAPI.Controllers.ApiModels
{
    public class CreatePayment
    {
        [Required]
        public int? ClientId { get; set; }

        [Required]
        public double? Amount { get; set; }

        [Required]
        public PaymentMethod Method { get; set; }

        [Required]
        public DateTime PaymentAt { get; set; }
    }

}