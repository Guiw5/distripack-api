using System.Collections.Generic;

namespace DistripackAPI.Controllers.ApiModels
{
    public class ClientHistory
    {
        public ICollection<Order> Orders { get; set; }

        public double TotalAmount { get; set; }

    }
}