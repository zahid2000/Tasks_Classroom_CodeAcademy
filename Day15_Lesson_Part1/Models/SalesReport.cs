using System;
using System.Collections.Generic;

namespace Day15_Lesson_Part1.Models
{
    public partial class SalesReport
    {
        public string CategoryName { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? ContactName { get; set; }
    }
}
