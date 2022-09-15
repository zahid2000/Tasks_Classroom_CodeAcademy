namespace DependencyInjectionAndMiddleWare.Infrastructure
{
    public class ShortCircuitMiddleWare
    {
        private RequestDelegate _requestDelegate;

        public ShortCircuitMiddleWare(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var result = httpContext.Request.Headers["User-Agent"].Any(h => h.ToLower().Contains("trident")); 
            if (httpContext.Items["IE"] as bool?==true)
            {
                httpContext.Response.StatusCode = 403;
            }
            else
            {
                await _requestDelegate.Invoke(httpContext);
            }
        }
    }

    public class ContentMiddleware
    {
        private RequestDelegate _requestDelegate;

    }
}
