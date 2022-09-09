using System;
using System.Collections.Generic;

namespace Day15_Lesson_Part1.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
