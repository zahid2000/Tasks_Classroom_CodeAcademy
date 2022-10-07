using Microservices.Category.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Category.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<DE.Category> CreateAsync(DE.Category category, CancellationToken cancellationToken)
        {
            return await _categoryRepository.CreateAsync(category, cancellationToken);
        }

        public async Task DeleteAsync(DE.Category category, CancellationToken cancellationToken)
        {
             await _categoryRepository.DeleteAsync(category, cancellationToken);
        }

        public Task<IEnumerable<DE.Category>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<DE.Category, bool>>? filter = null)
        {
           var result=
        }

        public Task<DE.Category> GetAsync(Expression<Func<DE.Category, bool>> filter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
