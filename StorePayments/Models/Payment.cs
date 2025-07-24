namespace ClothingStorePayments.Models
{
    public class Payment
    {
        public int Id { get; set; }

        public string UserEmail { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
    }
}
