using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(int id):IRequest;
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IApplicationDbContext _context; 

        public DeleteProductCommandHandler(IApplicationDbContext context )
        {
            _context = context; 
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.Where(x => x.Id == request.id).SingleOrDefaultAsync();
            if (entity==null)
            {
                throw new Exception("");//TODO:NotFoundException
            }
            _context.Products.Remove(entity);
          await  _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
