namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesOldController : ControllerBase
    {
        private readonly NorthwindDbContext _northwindDbContext;
        private readonly IMapper _mapper;
        private readonly IValidator<CategoryCreateDto> _validator;
        public CategoriesOldController(NorthwindDbContext northwindDbContext, IMapper mapper, IValidator<CategoryCreateDto> validator)
        {
            _northwindDbContext = northwindDbContext;
            _mapper = mapper;
            _validator = validator;
        }

        #region Old
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

        /// <summary>
        /// Create New Category
        /// </summary>
        /// <param name="categoryCreateDto">CreateCategoryDto CreateCategoryDto</param>
        /// <returns>A newly created Category</returns>
        [HttpPost]
        public async Task<CategoryDto>  Post(
            [FromBody] CategoryCreateDto categoryCreateDto)
        {

            //ValidationResult validateResult=await _validator.ValidateAsync(categoryCreateDto);
            //if (!validateResult.IsValid)
            //{

            //}
            //var result = await _northwindDbContext.Categories.AddAsync(_mapper.Map<Category>(categoryCreateDto));
            //await _northwindDbContext.SaveChangesAsync();
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
        #endregion

    }
}
