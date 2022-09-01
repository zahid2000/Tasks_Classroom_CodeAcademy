using Day8_Lesson_Part2.Models;
Company company = new Company();


while (true)
{
    if (company.GetUsers().Count == 0)
    {
        Console.WriteLine("Qeydiyyatdan kecin!");
        Register(company);
    }
    else
    {
        Console.WriteLine("1.Qeydiyyatdan kecin\n2.Hesabiniza daxil olun");
        string answer = Console.ReadLine();
        if (answer == "1")
        {
            Register(company);
        }
        else if (answer == "2")
        {
            Console.WriteLine("Hesabiniza daxil olun");
            Login(company);
        }
    }
}






void Login(Company company)
{

    Console.WriteLine("Username daxil edin");
    string LoginUsername = Console.ReadLine();
    Console.WriteLine("Password daxil edin");
    string LoginPassword = Console.ReadLine();
    company.Login(LoginUsername, LoginPassword);

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(new String('-', 100));
    Console.ResetColor();


}


void Register(Company company)
{
    bool result;
    Console.WriteLine("Adi Daxil edin");
    string name = Console.ReadLine();
    result = company.checkUsername(name);
    if (!result) ErrorRegister(company);
    Console.WriteLine("Soyad daxil edin");
    string surname = Console.ReadLine();
    result = company.checkSurname(surname);
    if (!result) ErrorRegister(company);

    Console.WriteLine("Password daxil edin");
    string password = Console.ReadLine();
    result = company.checkPassword(password);
    if (!result) ErrorRegister(company);
    User user = new User
    {
        Name = name,
        Surname = surname,
        Password = password
    };
    company.Register(user);

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(new String('-', 100));
    Console.ResetColor();

   
}

void ErrorRegister(Company company)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Yeniden qeydiyyatdan kecin");
    Console.ResetColor();
    //Register(company);
}

