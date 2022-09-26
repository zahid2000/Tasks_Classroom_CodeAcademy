using System.ComponentModel.DataAnnotations;

namespace Login_Register_App.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        
        public string? UserName { get; set; }
         
        public string? Email { get; set; } 
        public byte[] Password { get; set; }

    }
}
