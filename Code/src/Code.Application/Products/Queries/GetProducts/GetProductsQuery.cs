using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery:IRequest<IEnumerable<GetProductReponse>>;
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<GetProductReponse>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public GetProductsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetProductReponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.AsNoTracking()
                                             .ProjectTo<GetProductReponse>(_mapper.ConfigurationProvider)
                                             .OrderBy(x=>x.ProductName)
                                             .ToListAsync();
            return products;
        }
    }

}
