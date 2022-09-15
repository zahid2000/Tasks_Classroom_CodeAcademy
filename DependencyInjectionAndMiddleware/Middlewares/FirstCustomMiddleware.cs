namespace DependencyInjectionAndMiddleware.Middlewares
{
    public class FirstCustomMiddleware
    {

        private readonly RequestDelegate _next;
        public FirstCustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            
            Console.WriteLine("FirstCustomMiddleware -> Start (Hello World)");
            await _next.Invoke(context);

            Console.WriteLine("FirstCustomMiddleware -> End (Hello World)");
          
        }

    }
}
