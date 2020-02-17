using MeetingManagement.DL;
using MeetingManagement.DL.Repository.Abstract;
using MeetingManagement.Web.Infrastructure;
using MeetingManagement.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace MeetingManagement.Web.Controllers
{
    [Route("")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IRepositoryBase<User> _userRepo;
        private readonly AuthOptions _authOptions;

        public AuthenticateController(IRepositoryBase<User> userRepo,
            IOptions<AuthOptions> authOptionsAccessor)
        {
            _userRepo = userRepo;
            _authOptions = authOptionsAccessor.Value;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult Login([FromBody] LoginVM model) 
        {
            var user = _userRepo.GetAll().FirstOrDefault(u => u.UserName == model.Username && u.Password == model.Password);

            if(user != null)
            {
                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken(
                    issuer: _authOptions.Issuer,
                    audience: _authOptions.Audience,
                    expires: DateTime.Now.AddHours(_authOptions.ExpiresInMinutes),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authOptions.SecureKey)),
                        SecurityAlgorithms.HmacSha256Signature)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}