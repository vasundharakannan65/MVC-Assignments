using InterviewEvaluationApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InterviewEvaluationApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;


        public AccountController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._configuration = configuration;
        }


        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] Register register)
        {
            var userExist = await _userManager.FindByNameAsync(register.UserName);

            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "UserName is already exists!" });
            }

            ApplicationUser user = new()
            {
                UserName = register.UserName,
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString()

            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Registration Failed!" });
            }

            if (!await _roleManager.RoleExistsAsync("Administrator"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            if (await _roleManager.RoleExistsAsync("Administrator"))
            {
                await _userManager.AddToRoleAsync(user, "Administrator");
            }

            return Ok(new Response { Status = "Success", Message = "User has been registered successfully!" });


        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] Register register)
        {
            var userExist = await _userManager.FindByNameAsync(register.UserName);

            if(userExist != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "UserName is already exists!" });
            }

            ApplicationUser user = new()
            {
                UserName = register.UserName,
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString()

            };

            var result = await _userManager.CreateAsync(user, register.Password);

            if(!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User Registration Failed!" });
            } 
  
            if(! await _roleManager.RoleExistsAsync("HR"))
            {
                 await _roleManager.CreateAsync(new IdentityRole("HR"));
            }
            if (!await _roleManager.RoleExistsAsync("Interviewer"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Interviewer"));
            }

            if(register.HR == true)
            {
                await _userManager.AddToRoleAsync(user, "HR");
            }
            else
            {
                await _userManager.AddToRoleAsync(user, "Interviewer");
            }


            return Ok(new Response { Status = "Success", Message = "User has been registered successfully!" });
            

        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);

            if(user != null && await _userManager.CheckPasswordAsync(user,login.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                };

                foreach (var role in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer : _configuration["JWT:ValidIssuer"],
                    audience : _configuration["JWT:ValidAudience"],
                    expires : DateTime.Now.AddHours(3),
                    claims : authClaims,
                    signingCredentials : new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            } 
            else
            {
                return Unauthorized();
            }
        }
    }
}
