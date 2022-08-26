using Day4_Lesson_Part2.Models.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_Lesson_Part2.Models
{
    public class Hotel
    {
        public Hotel(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        private Room[] Rooms =new Room[0];
        public void AddRoom(Room room) {
            Array.Resize<Room>(ref Rooms, Rooms.Length + 1);
            Rooms[Rooms.Length - 1] = room;
        }
        public bool MakeReservation(int roomId)
        {
            var result = Array.Find(Rooms, r => r.Id == roomId);
            if ( result==null)
            {
                throw new NotAviableException("Bu otaq yoxdur");
            }
            else
            {
                if (!result.IsAviable)
                {
                    throw new Exception("Bu otaq bos deyil");
                }
                else
                {
                    Console.WriteLine(result.IsAviable);
                    return result.IsAviable;
                }
               
            }
        }
    }
}
