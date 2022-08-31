using Day5_Lesson_Part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Lesson_Part1.Services
{
    internal class FryBaconService
    {

        public static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine($"cooking first of bacon");
            Task.Delay(3000).Wait();
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second bacon...");
            Task.Delay(3000).Wait();
            return new Bacon();
        }
        public static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine($"cooking first of bacon");
            Task.Delay(3000).Wait();
            for (int i = 0; i < slices; i++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second bacon...");
            Task.Delay(3000).Wait();
            return new Bacon();
        }
    }
}
