using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RMNCAH_api.Data;
using RMNCAH_api.Models.Security;
//using Serilog;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RMNCAH_api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDBContext _applicationDbContext;

        public UserController(IOptionsSnapshot<JwtSettings> jwtSettings, UserManager<User> userManager, ApplicationDBContext applicationDbContext)
        {
            _jwtSettings = jwtSettings.Value;
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
        }

        private string GenerateJwt(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            };
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(UserLoginResource userLoginResource)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.UserName == userLoginResource.Username);
            if (user is null)
            {
                return Unauthorized("Invalid Credentials");
            }

            //if user is de-activated prevent login
            if (!user.Active)
            {
                return Unauthorized("User De-activated. Please contact the administrator.");
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);

            if (userSigninResult)
            {
                //_logger.Information("{Username} logged in successfully", user.UserName);

                //var roles = await _userManager.GetRolesAsync(user);

                return Ok(GenerateJwt(user));
            }

            //_logger.Warning("Failed login attempt for : {Username}", user.UserName);
            return Unauthorized("Invalid credentials.");
        }

        [HttpGet("changepassword")]
        public int ChangePwdCheck(UserChangePassword userChangePassword)
        {
            var user = _applicationDbContext.Users
                .Where(u => u.UserName == userChangePassword.UserName)
                .FirstOrDefault();

            return user.ChangePassword;
        }

        [HttpPost("changepassword")]
        public async Task<IActionResult> ChangePassword(UserChangePassword userChangePassword)
        {
            //var user = await _userManager.GetUserAsync(User);
            var user = _applicationDbContext.Users.Where(r => r.Id == userChangePassword.UserId).FirstOrDefault();
            var result = await _userManager.ChangePasswordAsync(user, userChangePassword.CurrentPassword, userChangePassword.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    //add errors error.Description
                }

                return BadRequest("Error occured!!!");
            }

            user.ChangePassword = 0;
            _applicationDbContext.SaveChanges();

            return Ok("Password updated successfully");

        }
    }
}
