


namespace Microservices.Category.Repositories.Concrete;

public class CategoryRepository : BaseRepository<DE.Category, ApplicationDbContext>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext context) : base(context)
    {
    }
}
