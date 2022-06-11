using api.Enums;
using api.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<IEnumerable<UserModel>> GetAllCustomers();
        Task<UserModel> GetById(int id);
        Task<IEnumerable<RoleModel>> GetRoles();
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
