using Day3_Tasks_Part2.Models;

            //Car car = new Car(2022, "BMW", "X6", -1, 2);
            //Console.WriteLine(car.Year);
            //Console.WriteLine(car.FuelFor1Km);
            //Console.WriteLine(car.CurrentFuel);

            Frontend frontend = new Frontend();

            Console.WriteLine("Frontendin adini daxil edin");
            frontend.Name = Console.ReadLine();

            Console.WriteLine("Frontendin soy adini daxil edin");
            frontend.Surname = Console.ReadLine();
            Console.WriteLine("Frontendin yasini daxil edin");
            frontend.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Frontendin tecrubesini daxil edin");
            frontend.Experiance = int.Parse(Console.ReadLine());
            Console.WriteLine($"FullName : {frontend.GetFullName()} age : {frontend.Age} experiance : {frontend.Experiance}");
 


