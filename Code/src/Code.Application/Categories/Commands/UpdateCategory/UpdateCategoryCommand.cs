using Code.Application.Common.Interfaces;

namespace Code.Application.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand:IRequest
{
    public int Id { get; set; }
    public string CategoryName { get; set; } = null!;
    public string? Description { get; set; }
}
public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity=await _context.Categories.FindAsync(new object[] {request.Id},cancellationToken);

        if (entity==null)
        {
            throw new Exception("");//TODO:NotFoundException sinfi hazirlanacak;
        }
        entity.CategoryName = request.CategoryName;
        entity.Description = request.Description;
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}