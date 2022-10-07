using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Common.Dtos
{
    public class UserCreateDto
    {
        public string UsereName { get; set; } = null!;
        public string Password { get; set; }=null!;
    }
  
}
