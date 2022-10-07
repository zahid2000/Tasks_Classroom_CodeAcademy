using Code.Application.Common.Dtos;
using Code.Application.Common.Models;
using Code.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Infrastructure.Service
{
    public class IdentityService : IIdentityService
    {
        #region Constructor
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService, IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory)
        {
            _userManager = userManager;
            _authorizationService = authorizationService;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        } 
        #endregion

        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user=await _userManager.Users.SingleOrDefaultAsync(u=>u.Id==userId);
            if (user==null)
            {
                return false;
            }
            var principal=await _userClaimsPrincipalFactory.CreateAsync(user);
            var result=await _authorizationService.AuthorizeAsync(principal, policyName);
            return result.Succeeded;
        }

        public async Task<Result> ResetUserPasswordAsync(string userName, string password)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u=>u.UserName== userName);
            if (user==null)
            {
                return Result.Failure(new string[] { "User not found" });
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);
          IdentityResult result=  await _userManager.ResetPasswordAsync(user, token, password);
            if (result.Succeeded)
            {
                return Result.Success();
            }
            return result.ToApplicationResult();
        }

        public async Task<(Result Result, string userId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName
            };
            var result=await _userManager.CreateAsync(user, password);
            return (result.ToApplicationResult(),user.Id);
        }

        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }
        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
         var result=   await _userManager.DeleteAsync(user);
            return result.ToApplicationResult();
        }

        public async Task<IEnumerable<ApplicationUserDto>> GetAllAsync()
        {
            return await _userManager.Users.Select(u => new ApplicationUserDto
            {
                UserName=u.UserName,
                Email=u.Email
            }).ToListAsync();
        }

        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user==null)
            {
                return String.Empty;
            }
            return user.UserName;
        }

        public async Task<bool> IsRoleAsync(string userId, string roleName)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.Id == userId);
            return user!=null&&await _userManager.IsInRoleAsync(user, roleName);

        }
    }
}
