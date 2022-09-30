﻿namespace WebAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public int SupplierID { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public string? QuantityPerUnit { get; set; }
        public float? UnitPrice { get; set; }
        public int? UnitsInStock { get; set; }
        public int? UnitsOnOrder { get; set; }
        public int? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
