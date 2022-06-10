﻿using api.Interfaces;
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
            var user = await Authenticate(loginInfo);

            if (user != null)
            {
                string token = GenerateToken(user);

                var res = new
                {
                    token,
                    fullName = user.FullName,
                    email = user.Email,
                    gender = user.Gender,
                    address = user.Address,
                    phone = user.Phone,
                    role = user.Role
                };

                return new
                {
                    Success = true,
                    Data = res
                };
            }

            return new
            {
                Success = false
            };
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
                    Success = true,
                    Data = userRegister
                };
            }
            catch (Exception) {}

            return new {
                Success = false,
                Message = "Server Error"
            };
        }

        private string GenerateToken(UserModel user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuation["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
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

        private async Task<UserModel> Authenticate(LoginModel userLogin)
        {
            var currentEmployee = await _context.Users.Where(employee =>
             employee.Email == userLogin.Email && employee.Password == userLogin.Password).FirstOrDefaultAsync();

            if (currentEmployee != null) return currentEmployee;

            return null;
        }
    }
}
