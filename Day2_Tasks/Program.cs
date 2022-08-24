namespace Day2_Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Sorting();
            int count = 0;
            int[] arr = { 121, 22, 33, 4, 523, -32, 3, 4, 6, 7, 4 };
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0 && arr[i]<10)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }

        private static void Sorting()
        {
            int[] numbers = { 121, 22, 33, 4, 523, -32, 3, 4, 6, 7, 4 };
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] > numbers[j])
                    {
                        int a = numbers[i];
                        numbers[i] = numbers[j];
                        numbers[j] = a;
                    }
                }
            }
            Console.WriteLine($"En kicik : {numbers[0]}");
            Console.WriteLine($"En boyuk : {numbers[numbers.Length - 1]}");
        }
    }
}