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

        [HttpGet]
        public List<User> getClientDetails()
        {
            using (_applicationDbContext)
            {
                return _applicationDbContext.Users.OrderBy(c => c.LastName).ToList();
            }
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
                new Claim("FirstName",  user.FirstName),
                new Claim("LastName",  user.LastName),
                new Claim("JobTitle",  user.JobTitle),
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

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(UserSignUpResource userSignUpResource)
        {
            //var user = _mapper.Map<UserSignUpResource, User>(userSignUpResource);
            User user = new User();
            user.UserName = userSignUpResource.UserName;
            user.FirstName = userSignUpResource.FirstName;
            user.LastName = userSignUpResource.LastName;
            user.JobTitle = userSignUpResource.JobTitle;
            user.Email = userSignUpResource.Email;
            user.Active = true;

            var userCreateResult = await _userManager.CreateAsync(user, userSignUpResource.Password);

            if (userCreateResult.Succeeded)
            {
                var newUser = _applicationDbContext.Users.Where(r => r.UserName == userSignUpResource.UserName).FirstOrDefault();

                var claims = await _userManager.GetClaimsAsync(newUser);
                var result = await _userManager.RemoveClaimsAsync(newUser, claims);

                /*if (userSignUpResource.UserRole == "ADMIN")
                {
                    var addUserRole = await _userManager.AddToRoleAsync(newUser, userSignUpResource.UserRole);
                }

                if (userSignUpResource.ChangePwdOnLogin == true)
                {
                    newUser.ChangePassword = 1;
                    _applicationDbContext.SaveChanges();
                }
                else
                {
                    newUser.ChangePassword = 0;
                    _applicationDbContext.SaveChanges();
                }*/

                return Created(string.Empty, string.Empty);
            }

            return Problem(userCreateResult.Errors.First().Description, null, 500);
        }

        [HttpPost("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile(UserSignUpResource userSignUpResource)
        {
            var user = _applicationDbContext.Users.Where(r => r.UserName.ToLower() == userSignUpResource.UserName.ToLower()).FirstOrDefault();
            user.FirstName = userSignUpResource.FirstName;
            user.LastName = userSignUpResource.LastName;

            var userUpdateResult = await _userManager.UpdateAsync(user);

            if (userUpdateResult.Succeeded)
            {
                return Ok();
            }

            return Problem(userUpdateResult.Errors.First().Description, null, 500);
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
            var user = _applicationDbContext.Users.Where(r => r.Id == userChangePassword.UserId).FirstOrDefault();
            var result = await _userManager.ChangePasswordAsync(user, userChangePassword.CurrentPassword, userChangePassword.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    //add errors error.Description
                }

                return BadRequest(result.Errors);
            }

            user.ChangePassword = 0;
            _applicationDbContext.SaveChanges();

            return Ok("Password updated successfully");

        }
    }
}
