using api.Enums;
using api.Interfaces;
using api.Models;
using api.Models.OtherModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public IUser _user;

        public UsersController(IUser user)
        {
            _user = user;
        }

        // GET api/users
        [HttpGet]
        [Route("")]
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _user.GetAllUsers();
        }

        // GET api/users/customers
        [HttpGet]
        [Route("customers")]
        public async Task<IEnumerable<UserModel>> GetAllCustomers()
        {
            return await _user.GetAllCustomers();
        }

        // GET api/users/roles
        [HttpGet]
        [Route("roles")]
        public async Task<IEnumerable<RoleModel>> GetRoles()
        {
            return await _user.GetRoles();
        }

        // GET api/users/3
        [HttpGet("{id}")]
        public async Task<UserModel> GetById(int id)
        {
            return await _user.GetById(id);
        }

        // POST api/users
        [HttpPost]
        public async Task<UserModel> Add(UserModel user)
        {
            return await _user.Add(user);
        }

        // PUT api/users/3
        [HttpPut("{id}")]
        public async Task<UserModel> Update(UserModel user, int id)
        {
            return await _user.Update(user, id);
        }

        // DELETE api/users/4
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _user.Delete(id);
        }
    }
}
