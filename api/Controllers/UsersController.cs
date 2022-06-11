using api.Enums;
using api.Interfaces;
using api.Models;
using api.Models.OtherModels;
using api.Models.Request;
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
        public async Task<dynamic> GetAllUsers()
        {
            return await _user.GetAllUsers();
        }

        // GET api/users/customers
        [HttpGet]
        [Route("customers")]
        public async Task<dynamic> GetAllCustomers()
        {
            return await _user.GetAllCustomers();
        }

        // GET api/users/roles
        [HttpGet]
        [Route("roles")]
        public async Task<dynamic> GetRoles()
        {
            return await _user.GetRoles();
        }

        // GET api/users/3
        [HttpGet("{id}")]
        public async Task<dynamic> GetById(int id)
        {
            return await _user.GetById(id);
        }

        // POST api/users
        [HttpPost]
        public async Task<dynamic> Add(UserModel user)
        {
            return await _user.Add(user);
        }

        // PUT api/users/3
        [HttpPut("{id}")]
        public async Task<dynamic> Update(UpdateUserReqModel user, int id)
        {
            return await _user.Update(user, id);
        }

        // DELETE api/users/4
        [HttpDelete("{id}")]
        public async Task<dynamic> Delete(int id)
        {
            return await _user.Delete(id);
        }
    }
}
