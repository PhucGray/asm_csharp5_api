using api.Models;
using api.Models.MockData;
using api.Models.OtherModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuation;

        public LoginController(IConfiguration configuation)
        {
            _configuation = configuation;   
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginModel userLogin)
        {
            var user = Authenticate(userLogin);

            if(user != null)
            {
                var token = GenerateToken(user);

                var res = new
                {
                    token,
                    fullName = user.FullName,
                    email = user.Email,
                    gender = user.Gender,
                    address = user.Address,
                    phone = user.Phone
                };

                return Ok(res);
            }

            return NotFound("Email hoặc mật khẩu không đúng");
        }

        private string GenerateToken(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuation["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("FullName", user.FullName),
                new Claim("Role", user.RoleId.ToString()),
                new Claim("Email", user.Email)
            };

            var token = new JwtSecurityToken(_configuation["Jwt:Issuer"],
              _configuation["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel Authenticate(LoginModel userLogin)
        {
            if(userLogin.IsEmployee == true)
            {
                var currentUser = MockCustomerData.Customers.FirstOrDefault(user =>
              user.Email == userLogin.Email && user.Password == userLogin.Password);

                if (currentUser != null) return currentUser;
            } 

            if(userLogin.IsEmployee == false)
            {
                var currentUser = MockUserData.Users.FirstOrDefault(user =>
               user.Email == userLogin.Email && user.Password == userLogin.Password);

                if (currentUser != null) return currentUser;
            }
           

            return null;
        }
    }
}
