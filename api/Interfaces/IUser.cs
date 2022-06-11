using api.Enums;
using api.Models;
using api.Models.Request;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IUser
    {
        Task<dynamic> GetAllUsers();
        Task<dynamic> GetAllCustomers();
        Task<dynamic> GetById(int id);
        Task<dynamic> GetRoles();
        Task<dynamic> Add(UserModel user);
        Task<dynamic> Update(UpdateUserReqModel user, int id);
        Task<dynamic> Delete(int id);
    }
}
