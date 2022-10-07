
namespace Microservices.Category.Dtos
{
    public class CreateCategoryDto:IMapFrom<DE.Category>
    {
        public string CategoryName { get; set; } = null!;
    }
}
