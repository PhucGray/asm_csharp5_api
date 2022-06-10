using api.Interfaces;
using api.Models;
using api.Models.OtherModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace api.Services

{
    public class AuthService : IAuth
    {
        protected DataContext _context;
        private readonly IConfiguration _configuation;  

        public AuthService(IConfiguration configuation, DataContext context)
        {
            _context = context;
            _configuation = configuation;
        }

        public async Task<dynamic> Login(LoginModel loginInfo)
        {
            try
            {
                var user = await Authenticate(loginInfo);

                if (user != null)
                {
                    string token = GenerateToken(user);

                    var res = new ProfileResModel
                    {
                        Token = token,
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        Gender = user.Gender,
                        Address = user.Address,
                        Phone = user.Phone,
                        Role = user.Role
                    };

                    return new
                    {
                        Success = true,
                        Data = res
                    };
                }

                return new
                {
                    Success = false,
                    Message = "Email hoặc mật khẩu không chính xác"
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Server error: login"
                };
            }
        }

        public async Task<dynamic> Register(UserModel userRegister)
        {
            try
            {
                var dbUser = await _context.Users
                                       .Where(user => user.Email == userRegister.Email)
                                       .FirstOrDefaultAsync();

                if (dbUser != null) return new
                {
                    Success = false,
                    Message = "Email đã được đăng ký"
                };

                await _context.Users.AddAsync(userRegister);
                await _context.SaveChangesAsync();

                return new {
                    Success = true
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Server Error"
                };
            };
        }

        public dynamic GetProfile(string token)
        {
            try
            {
                int id = int.Parse(DecodeToken(token));

                var user = _context.Users.Find(id);

                if (user != null)
                {
                    var res = new ProfileResModel
                    {
                        Id = user.Id,
                        FullName = user.FullName,
                        Email = user.Email,
                        Gender = user.Gender,
                        Address = user.Address,
                        Phone = user.Phone,
                        Role = user.Role
                    };

                    return new
                    {
                        Success = true,
                        Data = res
                    };
                }

                return new {
                    Success = false,
                    Message = "Get profile error"
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "Server error: get profile"
                };
            }
        }

        private string GenerateToken(UserModel user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuation["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("FullName", user.FullName),
                new Claim("Email", user.Email),
                new Claim("Role", user.Role.ToString()),
            };

            var token = new JwtSecurityToken(_configuation["Jwt:Issuer"],
              _configuation["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private dynamic DecodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var id = jwtSecurityToken.Claims.First(claim => claim.Type == "Id").Value;

            return id;
        }
        private async Task<UserModel> Authenticate(LoginModel userLogin)
        {
            var user = await _context.Users.Where(user =>
             user.Email == userLogin.Email && user.Password == userLogin.Password).FirstOrDefaultAsync();

            if (user != null) return user;

            return null;
        }
    }
}
