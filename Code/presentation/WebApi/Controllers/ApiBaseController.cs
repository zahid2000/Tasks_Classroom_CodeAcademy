namespace Code.WebApi.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        private ISender _mediatr = null;
        public ISender Mediator=>_mediatr??=HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
