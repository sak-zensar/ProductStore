namespace Service.Models
{
    public class ProductSearch
    {
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? UnitId { get; set; }
    }
}