﻿
namespace Code.Application.Categories.Queries.GetCategories;

public record GetCategoriesQuery:IRequest<IEnumerable<CategoryDto>>;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetCategoriesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories=await _context.Categories
                                               .AsNoTracking()
                                               .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                                               .OrderBy(x=>x.CategoryName)
                                               .ToListAsync();
        return categories; 
    }
}
