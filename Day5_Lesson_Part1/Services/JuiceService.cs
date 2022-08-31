using Day5_Lesson_Part1.Models;

namespace Day5_Lesson_Part1.Services
{
    internal class JuiceService
    {
        public static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
        public static async Task<Juice> PourOJAsync()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
    }
}
