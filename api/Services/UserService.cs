using api.Enums;
using api.Helpers;
using api.Interfaces;
using api.Models;
using api.Models.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace api.Services
{
    public class UserService : IUser
    {
        protected DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<dynamic> GetAllUsers()
        {
            try
            {
                var users = await _context.Users.Where(user => user.RoleId != 1).ToListAsync();

                return new
                {
                    Success = true,
                    Data = users
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "User(GetAll): error"
                };
            }
        }

        public async Task<dynamic> GetAllCustomers()
        {
            try
            {
                var customers = await _context.Users.Where(user => user.RoleId == 1).ToListAsync();
                return new { 
                    Success = true,
                    Data = customers
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "User(GetAllCustomers): error"
                };
            }
        }

        public async Task<dynamic> GetById(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                return new
                {
                    Success = true,
                    Data = user
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "User(GetById): error"
                };
            }
        }

        public async Task<dynamic> GetRoles()
        {
            
            try
            {
                var roles = await _context.Roles.Where(role => role.Id != 0).ToListAsync();
                return new
                {
                    Success = true,
                    Data = roles
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false,
                    Message = "User(GetRoles): error"
                };
            }
        } 

        public async Task<dynamic> Add(UserModel user)
        {
            try
            {
                var dbUserEmail = await _context.Users.Where(_user => _user.Email == user.Email).ToListAsync();
                var dbUserPhone = await _context.Users.Where(_user => _user.Phone == user.Phone).ToListAsync();

                if (dbUserEmail.Count > 0) return new { 
                    Success = false,
                    Message = "Email đã tồn tại"
                };

                if (dbUserPhone.Count > 0) return new
                {
                    Success = false,
                    Message = "Số điện thoại đã tồn tại"
                };

                user.Password = Password.Hash(user.Password);

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return new { 
                    Success = true,
                    Data = user
                };
            }
            catch (Exception)
            {

            }

            return new
            {
                Success = false,
                Message = "User(Add): error"
            };
        }

        public async Task<dynamic> Update(UpdateUserReqModel newUser, int id)
        {
            try
            {
                var user = _context.Users.Find(id);

                var dbUserEmail = await _context.Users.Where(_user => _user.Email == newUser.Email).ToListAsync();
                var dbUserPhone = await _context.Users.Where(_user => _user.Phone == newUser.Phone).ToListAsync();

                if (dbUserEmail.Count > 0 && newUser.Email != user.Email) return new
                {
                    Success = false,
                    Message = "Email đã tồn tại"
                };

                if (dbUserPhone.Count > 0 && newUser.Phone != user.Phone) return new
                {
                    Success = false,
                    Message = "Số điện thoại đã tồn tại"
                };

                user.FullName = newUser.FullName;
                user.Email = newUser.Email;
                user.Address = newUser.Address;
                user.Phone = newUser.Phone;
                user.Gender = newUser.Gender;
                user.RoleId = newUser.RoleId;
                user.IsDeleted = newUser.IsDeleted;

                await _context.SaveChangesAsync();

                return new
                {
                    Success = true,
                    Data = user
                };
            }
            catch (Exception)
            {
            }

            return new
            {
                Success = false,
                Message = "User(Update): error"
            };
        }

        public async Task<dynamic> Delete(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return new
                {
                    Success = true
                };
            }
            catch (Exception)
            {
                return new
                {
                    Success = false
                };
            }
        }
    }
}
