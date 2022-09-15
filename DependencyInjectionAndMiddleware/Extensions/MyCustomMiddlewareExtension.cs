using DependencyInjectionAndMiddleware.Middlewares;

namespace DependencyInjectionAndMiddleware.Extensions
{
    public static class MyCustomMiddlewareExtension
    {
        public static IApplicationBuilder UserMyFirstMIddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<FirstCustomMiddleware>();
        }
    }
}
