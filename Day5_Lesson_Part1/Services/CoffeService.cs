using Day5_Lesson_Part1.Models;

namespace Day5_Lesson_Part1.Services
{
    internal class CoffeService
    {
        public static Coffe PourCoffe()
        {
            Console.WriteLine("Pouring coffe");
            return new Coffe();
        }

        public static async Task<Coffe> PourCoffeAsync()
        {
            Console.WriteLine("Pouring coffe");
            return new Coffe();
        }
     }
}
