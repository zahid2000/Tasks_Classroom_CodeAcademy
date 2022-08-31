using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks.Models
{
    public class FirstClass
    {
        public int Yas
        {
            get => _yas;
            
            set
            {
                if (value >= 18 && value <= 55) { _yas = value; }
                else { throw new Exception("Yas dogru deyil"); }

            }
        }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string Mail { get; set; } = null!;//null ola bilmez
        public string?  Telefon { get; set; }
        private int _yas;

        public double Boy { get; set; }

    }
}
