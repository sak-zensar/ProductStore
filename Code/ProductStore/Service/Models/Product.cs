﻿namespace Service.Models
{
    public class Product
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int UnitId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}