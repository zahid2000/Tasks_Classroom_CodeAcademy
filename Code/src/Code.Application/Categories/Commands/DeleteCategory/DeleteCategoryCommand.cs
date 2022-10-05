    using Code.Application.Categories.Commands.CreateCategory;
using Code.Application.Common.Exceptions;
using Code.Application.Common.Interfaces;
using MediatR;

namespace Code.Application.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int id) : IRequest;
  
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categories.Where(x => x.Id == request.id).SingleOrDefaultAsync();
            if (entity==null)
            {
                throw new NotFoundException(nameof(DeleteCategoryCommand),request.id);
            }
            _context.Categories.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
