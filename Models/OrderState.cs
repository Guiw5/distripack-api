namespace DistripackAPI.Models
{
    public enum OrderState
    {
        Created = 0,
        Printed = 1,
        InDelivery = 2,
        Delivered = 3,
        Cancelled = -1,
    }
}