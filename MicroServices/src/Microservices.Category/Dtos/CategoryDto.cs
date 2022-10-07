using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Category.Dtos
{
    public class CategoryDto:IMapFrom<DE.Category>
    {
        public string CategoryName { get; set; } = null!;
    }
}
