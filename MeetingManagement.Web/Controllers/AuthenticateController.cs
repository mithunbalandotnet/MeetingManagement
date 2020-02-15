using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MeetingManagement.DL;
using MeetingManagement.DL.Repository.Abstract;
using MeetingManagement.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingManagement.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IRepositoryBase<User> _userRepo;

        public AuthenticateController(IRepositoryBase<User> userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginVM model) 
        {
            var user = _userRepo.GetAll().FirstOrDefault(u => u.UserName == model.Username && u.Password == model.Password);

            if(user != null)
            {
                var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
                };
            }

            return Unauthorized();
        }
    }
}