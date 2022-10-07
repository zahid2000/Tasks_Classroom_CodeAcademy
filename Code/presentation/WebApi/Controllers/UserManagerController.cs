using Code.Application.Common.Dtos;
using Code.Application.Common.Interfaces;
using Code.Application.Common.Models;
using System.Net;

namespace Code.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ApiBaseController
    {
        private readonly IIdentityService _identityService;

        public UserManagerController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _identityService.GetAllAsync();
            if (result != null)
            {
                return Ok(new
                {
                    result=result,
                    statusCode=HttpStatusCode.OK,
                    message="User List"
                });
            }
            return BadRequest();
        }

        [HttpGet("GetUserName")]
        public async Task<IActionResult> GetUserNameAsync(string userId)
        {
            var result = await _identityService.GetUserNameAsync(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost("IsRole")]
        public async Task<IActionResult> IsRoleAsync(string userId, string roleName)
        {
            var result=await _identityService.IsRoleAsync(userId, roleName);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Authorize")]
        public async Task<IActionResult> AuthorizeAsync(string userId, string policyName)
        {
            var result = await _identityService.AuthorizeAsync(userId, policyName);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("CreateUser")]
      public  async Task<IActionResult> CreateUserAsync(UserCreateDto userCreateDto)
        {
            var result=await _identityService.CreateUserAsync(userCreateDto.UsereName, userCreateDto.Password);
            if (result.Result.Succeeded)
            {
                return Ok(new
                {
                    StatusCode= HttpStatusCode.Created,
                    UserId=result.userId,
                    Message="UserCreated"
                });
            }
            return BadRequest(result.Result.Errors);
        }
        [HttpDelete]
      public  async Task<IActionResult> DeleteUserAsync(string userId)
        {
            var result=await _identityService.DeleteUserAsync(userId);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("ResetUserPassword")]
       public async Task<IActionResult> ResetUserPasswordAsync(UserCreateDto userCreateDto)
        {
            var result = await _identityService.ResetUserPasswordAsync(userCreateDto.UsereName,userCreateDto.Password);
            if (result.Succeeded)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
    }
}
