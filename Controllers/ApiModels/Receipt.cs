namespace DistripackAPI.Controllers.ApiModels
{
    public class Receipt : Transaction
    {
        public int OrderId { get; set; }
    }
}