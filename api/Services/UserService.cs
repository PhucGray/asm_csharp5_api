using api.Helpers;
using api.Interfaces;
using api.Models;
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

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<UserModel> Add(UserModel user)
        {
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception)
            {

            }

            return null;
        }

        public async Task<UserModel> Update(UserModel newUser, int id)
        {
            try
            {
                var user = _context.Users.Find(id);

                user.FullName = newUser.FullName;
                user.Email = newUser.Email;
                user.Password = newUser.Password;
                user.Address = newUser.Address;
                user.Phone = newUser.Phone;
                user.Gender = newUser.Gender;
                user.Role = newUser.Role;
                user.IsDeleted = newUser.IsDeleted;

                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var user = _context.Users.Find(id);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
