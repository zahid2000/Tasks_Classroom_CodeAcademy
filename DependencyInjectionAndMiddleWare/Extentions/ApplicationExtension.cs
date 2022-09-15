using DependencyInjectionAndMiddleWare.Infrastructure;

namespace DependencyInjectionAndMiddleWare.Extentions
{
    public static class ApplicationExtension
    {
        public static IApplicationBuilder UseContent(this IApplicationBuilder app,bool? isEnabled = null)
        {
            if (isEnabled.Value)
            {
                app.UseMiddleware<ShortCircuitMiddleWare>();
                
            }
            return app.UseMiddleware<ShortCircuitMiddleWare>();
        }
    }
}
