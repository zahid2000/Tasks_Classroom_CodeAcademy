using İnfastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class AddInfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection app)
        {
            app.AddDbContext<ApplicationDbContext>(opt =>

            {
                opt.UseSqlServer("Server=DESKTOP-QBQM5QA\\SQLEXPRESS;Database=JWT_MediatR;Trusted_Connection=true");
            }
            );
            return app;
        }
    }
}
