using Code.Application.Common.Dtos;
using Code.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<IEnumerable<ApplicationUserDto>> GetAllAsync();
        Task<bool> IsRoleAsync(string userId,string roleName);
        Task<bool> AuthorizeAsync (string userId,string policyName);
        Task<(Result Result, string userId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(string userId);
        Task<Result> ResetUserPasswordAsync(string userName, string password);
    }
}
