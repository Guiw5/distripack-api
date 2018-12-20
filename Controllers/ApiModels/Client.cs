using System;

namespace DistripackAPI.Controllers.ApiModels
{
    public class Client : ApiModel
    {
        public int Id { get; set; }

        public String Nick { get; set; }

        public String Mail { get; set; }
    }
}
