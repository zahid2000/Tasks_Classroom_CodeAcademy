using Code.Application.Common.Interfaces;
using MediatR;

namespace Code.Application.Categories.Commands.CreateCategory;

public class CreateCategoryCommand:IRequest<int>,IMapFrom<Category>
{
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
}

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Category>(request);
    //    var entity = new Category
    //    {
    //        CategoryName = request.CategoryName,
    //        Description = request.Description
    //};
        _context.Categories.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
       return entity.Id;
    }
}