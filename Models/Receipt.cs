namespace DistripackAPI.Models
{
    public class Receipt : Transaction
    {
        public Receipt() : base(TransactionType.Receipt) { }

        public Receipt(int checkingAccountId, int orderId, double amount)
            : base(checkingAccountId, TransactionType.Receipt, amount)
        {
            OrderId = orderId;
        }

        public int OrderId { get; private set; }
        public Order Order { get; private set; }
    }
}