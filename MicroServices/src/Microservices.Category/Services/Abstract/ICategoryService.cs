using Application.Repositories.Abstract;
using Microservices.Category.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Category.Services.Abstract
{
    public interface ICategoryService 
    {
        Task<DE.Category> CreateAsync(CreateCategoryDto,CancellationToken cancellationToken);
        Task<DE.Category> GetAsync(Expression<Func<DE.Category, bool>> filter, CancellationToken cancellationToken);
        Task DeleteAsync(DE.Category category, CancellationToken cancellationToken);
        Task<IEnumerable<DE.Category>> GetAllAsync(CancellationToken cancellationToken,Expression<Func<DE.Category, bool>>? filter = null);
    }
}
