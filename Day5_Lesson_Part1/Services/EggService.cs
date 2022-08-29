using Day5_Lesson_Part1.Models;

namespace Day5_Lesson_Part1.Services
{
    internal class EggService
    {
        public static Egg FryEgg(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking eggs.....");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");
            return new Egg();

        }
        public static async Task<Egg> FryEggAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking eggs.....");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");
            return new Egg();

        }
    }
}
