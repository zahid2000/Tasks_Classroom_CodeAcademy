//System.IO
using System.Text;

#region Forma 1
//var user = new string[]
//{
//    "zahid mamedov",
//    "zahid@gmail.com",
//    "+994706587483"
//};

//string examplePath1 = @"C:\Users\zahid.pm\Desktop\Text\example1.txt";
//await File.WriteAllLinesAsync(examplePath1,user);
//string[] result = File.ReadAllLines(examplePath1);
//foreach (var line in result.Select((value,index)=>new {value,index}))
//{

//    Console.WriteLine($"{line.index+1} -> {line.value}");

//} 
#endregion

#region Forma 2
//string examplePath2 = @"C:\Users\zahid.pm\Desktop\Text";

//DirectoryInfo info=new DirectoryInfo(examplePath2);
//FileInfo[] txtFiles=info.GetFiles("*.txt",SearchOption.AllDirectories);
//foreach (var file in txtFiles)
//{
//    Console.WriteLine(file.Name);
//    Console.WriteLine(file.FullName);
//    Console.WriteLine(file.Length);
//    Console.WriteLine(file.DirectoryName);
//    Console.WriteLine(file.LinkTarget);
//    Console.WriteLine(file.Attributes);
//}


#endregion

#region Forma 3
//string examplePath3 = @"C:\Users\zahid.pm\Desktop\Text\exampleText3.txt";
//FileStream fs = File.Open(examplePath3, FileMode.Create);
//string loremIpsum = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum";
//byte[] rsBtyeArray = Encoding.Default.GetBytes(loremIpsum);
//fs.Write(rsBtyeArray, 0, rsBtyeArray.Length);
//fs.Position = 0;
//byte[] data = new byte[rsBtyeArray.Length];
//for (int i = 0; i < rsBtyeArray.Length; i++)
//{
//    data[i] = (byte)fs.ReadByte();
//}
//Console.WriteLine(Encoding.Default.GetString(data)); 
#endregion

#region Forma 4
//string examplePath4 = @"C:\Users\zahid.pm\Desktop\Text\exampleText4.txt";
//StreamWriter sw = File.CreateText(examplePath4);
//sw.WriteLine(" of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum\";");
//sw.WriteLine("Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lor");
//sw.WriteLine("d typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five ");
//sw.WriteLine("e of Letraset sheets containing Lo");
//sw.Close();
//StreamReader sr=File.OpenText(examplePath4);
//Console.Clear();
//Console.WriteLine("Peek : {0}" ,sr.Peek());
//Console.WriteLine("1. Eleman : {0}" ,sr.ReadLine());
//Console.WriteLine("Tum elemanlar : {0}" ,sr.ReadToEnd()); 
#endregion

#region Forms 5
//string examplePath5 = @"C:\Users\zahid.pm\Desktop\Text\exampleText5.txt";
//FileInfo dataFile= new FileInfo(examplePath5);
//BinaryWriter wr = new BinaryWriter(dataFile.OpenWrite());
//string randomText = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
//int age = 99;
//double height = 100;

//wr.Write(randomText);
//wr.Write(age);  
//wr.Write(height);
//wr.Close();

//BinaryReader br = new BinaryReader(dataFile.OpenRead());
////Console.WriteLine(br.Read().ToString());
//Console.WriteLine(br.ReadString());
//Console.WriteLine(br.ReadInt32());
//Console.WriteLine(br.ReadDouble());
//br.Close(); 
#endregion