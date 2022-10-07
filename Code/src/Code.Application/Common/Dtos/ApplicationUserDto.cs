using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Common.Dtos
{
    public class ApplicationUserDto
    {
        public string UserName { get; set; } = null!;
        public string? Email{ get; set; }
    }
}
