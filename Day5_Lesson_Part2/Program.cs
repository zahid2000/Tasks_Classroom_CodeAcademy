

using Day5_Lesson_Part2.Services;
using System.Diagnostics;
using System.Net;
using System.Text;

string[] Urls = { "https://www.codeproject.com/Questions/204778/Get-HTML-code-from-a-website-C", 
    "https://classroom.google.com/u/0/c/NTI2NjYzMzkxMDI2", "https://en.wikipedia.org/wiki/URL" ,
"https://docs.microsoft.com/tr-tr/dotnet/api/system.collections.generic.sorteddictionary-2?view=net-6.0",
"https://docs.microsoft.com/tr-tr/dotnet/api/system.collections.generic.sorteddictionary-2.enumerator?view=net-6.0"
};

List<Task<string>> tasks = new List<Task<string>>();
var finished=
foreach (var item in tasks)
{
    
}
Stopwatch stopWatch=new Stopwatch();
HttpClient client = new HttpClient();
#region forma1
Console.WriteLine("Http Web Request");
foreach (var item in Urls)
{
    stopWatch.Restart();
    var count = await HtmlService.CountAsync(item);
    Console.WriteLine($"{count}--{stopWatch.ElapsedMilliseconds}--seconds");
}
stopWatch.Stop();

Console.WriteLine(new string('_',50));
#endregion

#region forma2
Console.WriteLine("Http Client");
stopWatch.Start();
foreach (var item in Urls)
{
    stopWatch.Restart();

    string html = await client.GetStringAsync(item);
    Console.WriteLine($"{html.Length}--{stopWatch.ElapsedMilliseconds}--seconds");

}

stopWatch.Stop();
Console.ReadLine();
#endregion