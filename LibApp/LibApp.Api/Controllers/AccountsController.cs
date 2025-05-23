﻿using LibApp.Core.Interfaces;
using LibApp.Core.Models;
using LibApp.Core.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        public AccountsController(UserManager<AppUser> userManager, IConfiguration configuration, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            this.configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration configuration;
        private readonly IUnitOfWork _unitOfWork;

        [HttpPost("[action]")]
        [Produces("application/json")]
        public async Task<IActionResult> RegisterNewUser([FromBody] DtoNewUser user)
        {
            // Log the incoming user data
            Console.WriteLine($"Registering user: Name={user.name}, Email={user.email}");

            if (ModelState.IsValid)
            {
                AppUser appUser = new()
                {

                    UserName = user.name,
                    Email = user.email,
                };

                IdentityResult result = await _userManager.CreateAsync(appUser, user.password);
                if (result.Succeeded)
                {
                    // Instead of returning a string, return a JSON object indicating success

                    AppUser thisuser = await _userManager.FindByEmailAsync(user.email);
                    Console.WriteLine($"Role is {user.role}");
                    await _userManager.AddToRoleAsync(thisuser, user.role);
                    return Ok(new { message = thisuser.Id });
                }
                else
                {
                    // Collect errors and return them as a JSON array
                    var errors = result.Errors.Select(error => error.Description).ToArray();
                    return BadRequest(new { errors });
                }
            }

            // Return the model state errors as a JSON object
            var modelErrors = ModelState.Values
                                        .SelectMany(v => v.Errors)
                                        .Select(e => e.ErrorMessage)
                                        .ToArray();
            return BadRequest(new { errors = modelErrors });
        }

        [HttpPost]
        public async Task<IActionResult> Login(DtoLogin Login)
        {
            if (ModelState.IsValid)
            {
                AppUser user = await _userManager.FindByNameAsync(Login.UserName);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user, Login.Password))
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                        var roles = await _userManager.GetRolesAsync(user);
                        if (!roles.IsNullOrEmpty())
                        {
                            foreach (var role in roles)
                            {
                                Console.WriteLine($"Role is {role}");
                                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                            }
                        }
                        else
                        {
                            Console.WriteLine("There is no Roles there");
                        }
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: configuration["JWT:Issuer"],
                            audience: configuration["JWT:Audience"],
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: sc
                            );
                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };
                        return Ok(_token);
                    }
                    else
                    {
                        return Unauthorized(new { message = "Error in PassWord" });
                    }
                }
                else
                {
                    ModelState.AddModelError("Error", "User Name is invalid");
                }
            }
            return BadRequest(ModelState);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_userManager.Users.ToList());
        }

    }
}
