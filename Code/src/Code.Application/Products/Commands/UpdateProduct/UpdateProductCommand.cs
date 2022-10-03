using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand:IRequest
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
        public int? CategoryId { get; set; }
    }
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity =await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity==null)
            {
                throw new Exception("");//TODO: NotFoundException
            }
            entity.ProductName = request.ProductName;
            entity.UnitPrice = request.UnitPrice;
            entity.UnitsInStock = request.UnitsInStock;
            entity.CategoryId = request.CategoryId;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
