
#region HomeTask
//SortedDictionary<string, string> WriterBook = new SortedDictionary<string, string>();
//WriterBook.Add("Zahid", "Zahid's book");
//WriterBook.Add("Asgar", "Asgar's book");
//foreach (var item in WriterBook)
//{
//    Console.WriteLine(item.Key + " " + item.Value);
//}
//Console.WriteLine(WriterBook["Zahid"]);

//SortedDictionary<string, string>.KeyCollection keys = WriterBook.Keys;
//SortedDictionary<string, string>.ValueCollection values = WriterBook.Values;

//foreach (var item in keys)
//{
//    Console.WriteLine(item);
//}

//foreach (var item in values)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine(WriterBook.ContainsKey("Zahid"));

#endregion





using Day5_Lesson_Part1.Models;
using Day5_Lesson_Part1.Services;

#region Sync
Console.WriteLine("Pour Async");

Coffe coffe = CoffeService.PourCoffe();
Console.WriteLine("coffe is ready");

Egg egg = EggService.FryEgg(2);
Console.WriteLine("egs are ready");

Bacon bacon = FryBaconService.FryBacon(3);
Console.WriteLine("Bacons are ready");

Toast toast = ToastService.ToastBread(2);
Console.WriteLine("Toast is ready");

Juice juice = JuiceService.PourOJ();
Console.WriteLine("oj is ready");

Console.WriteLine("Breakfast is ready");



#endregion

#region Async
Console.WriteLine("Pour Async");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(new String('-',50));
Console.ResetColor();

Task<Coffe> coffeTask = CoffeService.PourCoffeAsync();
Console.WriteLine("coffe is ready");

Task<Egg> eggTaskc = EggService.FryEggAsync(2);
Console.WriteLine("egs are ready");

Task<Bacon> baconTask = FryBaconService.FryBaconAsync(3);
Console.WriteLine("Bacons are ready");

Task<Toast> toastTask = ToastService.ToastBreadAsync(2);
Toast toastAsync = await toastTask;
ToastService.ApplyButter(toastAsync);
ToastService.ApplyJam(toastAsync);

Task<Juice> juiceTask = JuiceService.PourOJAsync();
Console.WriteLine("oj is ready");

Console.WriteLine("Breakfast is ready");

#endregion