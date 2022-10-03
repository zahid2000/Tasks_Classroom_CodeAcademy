using Code.Application.Products.Queries.GetProducts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Queries.GetProduct
{
    public record GetProductQuery(int id):IRequest<GetProductReponse>;
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, GetProductReponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetProductQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetProductReponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.AsNoTracking()
                                         .Where(x => x.Id == request.id)
                                         .SingleOrDefaultAsync();
            var response=_mapper.Map<GetProductReponse>(product);
            return response;
                                       
                                         
        }
    }
}
