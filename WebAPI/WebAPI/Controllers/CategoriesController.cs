

using System.Text.Json.Serialization;
using WebAPI.Dtos.CategoryDtos;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly NorthwindDbContext _northwindDbContext;
        private readonly IMapper _mapper;

        public CategoriesController(NorthwindDbContext northwindDbContext, IMapper mapper)
        {
            _northwindDbContext = northwindDbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> Get()
        {
            //var result = await _northwindDbContext.Categories.Select(x=>new CategoryDto
            //{
            //    CategoryId = x.CategoryId,
            //    CategoryName = x.CategoryName,
            //    Description=x.Description
            //}).ToListAsync();
            var result = _mapper.Map<IEnumerable<CategoryDto>>(await _northwindDbContext.Categories.ToListAsync());
            return result;
        }
        [HttpGet("top-5")]
        public async Task<IEnumerable<CategoryDto>> GetTop5()
        {
            var result = await _northwindDbContext.Categories.Select(x => new CategoryDto
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                Description = x.Description
            }).Take(5).ToListAsync();
            return result;
        }
        [HttpPost]
        public async Task<CategoryDto>  Post(
            [FromQuery]CategoryCreateDto categoryCreateDto,
            [FromBody] CategoryCreateDto createDto,
            [FromHeader] HeadData headData)
        {
            var result = await _northwindDbContext.Categories.AddAsync(_mapper.Map<Category>(categoryCreateDto));
            await _northwindDbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(categoryCreateDto);
        }
        public class HeadData
        {
            [FromHeader]
            public string? CompanyName { get; set; }
            [FromHeader]
            public string? Email { get; set; }
            [FromHeader(Name ="User-Agent")]
            public string? UserAgent { get; set; }
            [FromHeader]
            public string? Accept { get; set; }
        }
    }
}
