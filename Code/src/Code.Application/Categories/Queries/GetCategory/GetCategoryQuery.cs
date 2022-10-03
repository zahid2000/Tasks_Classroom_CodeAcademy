﻿namespace Code.Application.Categories.Queries.GetCategory;

public record GetCategoryQuery(int id) : IRequest<CategoryDto>;

public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetCategoryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {

        var category = await _context.Categories
            .AsNoTracking()
            .Where(x => x.Id == request.id)
            .SingleOrDefaultAsync();
        var response=_mapper.Map<CategoryDto>(category);
        return response;
    }

}

