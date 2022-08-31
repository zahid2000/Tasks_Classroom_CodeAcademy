using Day4_Lesson_Part2.Models;
Room room1 = new Room("1-ci otaq",123,3,true);
Room room2 = new Room("2-ci otaq",130,2,false);

Hotel hotel = new Hotel("Golden");
hotel.AddRoom(room1);
hotel.AddRoom(room2);
try
{
    hotel.MakeReservation(1);

}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
try
{
    hotel.MakeReservation(2);   

}
catch (Exception ex)
{

    Console.WriteLine(ex.Message);
}
