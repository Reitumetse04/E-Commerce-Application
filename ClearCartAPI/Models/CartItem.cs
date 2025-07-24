namespace ClearCartApi.Models
{
    public class CartItem
    {
        public int Id { get; set; }              // Unique ID for each cart item
        public string? UserId { get; set; }       // To track which user's cart this belongs to
        public int ClothingId { get; set; }      // Reference to clothing item
        public string? Size { get; set; }         // e.g. S, M, L
        public int Quantity { get; set; }        // How many items
        public decimal Price { get; set; }       // Price per item
        public string? Description { get; set; }  // Short description
    }
}
