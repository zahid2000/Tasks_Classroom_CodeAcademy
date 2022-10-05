using Code.Application.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Code.WebApi.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                {typeof(NotFoundException),HandleNotFoundException },
                {typeof(ValidationException),HandleValidationException },
                {typeof(ForbiddenAccessException),HandleForbiddenAccessException },
            };
        }
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            HandleException(context);

            return base.OnExceptionAsync(context);
        }
        private void HandleException(ExceptionContext context)
        {
            Type type= context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }
            else
            {
                //Custom Exception eklenecek
            }
        }
        private void HandleNotFoundException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                //Send sms,mail,vs....
                context.ExceptionHandled=true;
                var details = new ProblemDetails
                {
                 Type=context.Exception.GetType().Name,
                    Title="This object was not found",
                    Detail=context.Exception.Message
                };
                context.Result = new NotFoundObjectResult(details);
            }
            //Not found exception
        }
        private void HandleValidationException(ExceptionContext context)
        {
            //Not found exception
        }
        private void HandleForbiddenAccessException(ExceptionContext context)
        {
            //Not found exception
        }
    }
}
