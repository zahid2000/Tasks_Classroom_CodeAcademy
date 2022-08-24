using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Test1
{

    class Program
    {

        static void Main(string[] args)
        {
            var result = true;
            string message = "Kayit ekleme islemi basarili";


            //Console.WriteLine($"Kayit ekleme islemi basarili {(result ? message+"li":message+"siz")}");
            //Tuple
            //(string userName, string password, bool login) userLogin = (string.Empty, string.Empty, false);//Tuple
            //var t=Tuple.Create<string,string,bool>("","",false);//Tuple
            while (true) {
                int en = int.Parse(Console.ReadLine());
                int[][] kub = new int[en][];
                for (int i = 0; i < kub.Length; i++)
                {
                    for (int j = 0; j < kub.Length; j++)
                    {
                        if (i==0||j==0||i==kub.Length-1||j==kub.Length-1)
                        {
                            Console.Write("x ");

                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    Console.WriteLine();
                }
                if (en==0)
                {
                    break;
                }
            }
       }

        private static void Login()
        {
            
            string userName = "admin";
            string password = "123";

           bool result = false;
            do
            {
                Console.WriteLine("Istifadeci adi daxil edin");
                string inUsername = Console.ReadLine();
                Console.WriteLine("Password  daxil edin");
                string inPassword = Console.ReadLine();
                result = inUsername == userName && inPassword == password;
                if (!result)
                {
                    Console.WriteLine("Giris basarisiz");
                }
            } while (!result);
            Console.WriteLine("Giris basarili");
             
        }


        private static void chechCart(string[] elements)
        {
            Console.WriteLine("Sebet doldu.Elave mehsul daxil etmek isteyirsiz? Y/N");
            var key = Convert.ToString(Console.ReadLine());
            if (key == "Y" || key == "y")
            {
                GetAllElements(elements);
                elements = AddElements(elements);
                chechCart(elements);
            }
            else if (key == "N" || key == "n")
            {
                GetAllElements(elements);

            }
            else
            {
                chechCart(elements);
            }
        }

        private static string[] AddElements(string[] elements)
        {
            Console.WriteLine("Daxil etmek istediyiniz mehsul sayi daxil edin");
            int size = Convert.ToInt32(Console.ReadLine());
            int oldLength = elements.Length;
            Array.Resize<string>(ref elements, elements.Length + size);
            for (int i = oldLength; i < elements.Length; i++)
            {
                Console.WriteLine("Daxil edin");
                elements[i] = Convert.ToString(Console.ReadLine());
            }

            return elements;
        }

        private static void GetAllElements(string[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.WriteLine(elements[i]);
            }
        }


        private static void GetElements()
        {
            int[] counts = { 10, 20, 30, 40, 50 };
            int sum = 0;
            for (int i = 0; i < counts.Length; i++)
            {
                Console.ReadKey();
                sum += counts[i];
                Console.WriteLine(counts[i] + " -> " + sum);
            }
        }

      private static  void ConvertInt(string[] sayilar)
        {
            int[] numbers=Array.ConvertAll<string, int>(sayilar,s=>int.Parse(s));
            
            //for (int i = 0; i < sayilar.Length; i++)
            //{
            //    Array.Resize(ref numbers, numbers.Length + 1);
            //    numbers[numbers.Length - 1] = int.Parse(sayilar[i]);
            //}
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + ",");
            }
        }
    }
}
