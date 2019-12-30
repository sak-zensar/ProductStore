namespace Models
{
    public class ProductDetails
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int UnitId { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
