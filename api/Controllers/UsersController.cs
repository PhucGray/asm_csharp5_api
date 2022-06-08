using api.Interfaces;
using api.Models;
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

        // GET api/foods
        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAll()
        {
            return await _user.GetAll();
        }

        // GET api/foods/3
        [HttpGet("{id}")]
        public async Task<UserModel> GetById(int id)
        {
            return await _user.GetById(id);
        }

        // POST api/foods
        [HttpPost]
        public async Task<UserModel> Add(UserModel user)
        {
            return await _user.Add(user);
        }

        // PUT api/foods/3
        [HttpPut("{id}")]
        public async Task<UserModel> Update(UserModel user, int id)
        {
            return await _user.Update(user, id);
        }

        // DELETE api/foods/4
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _user.Delete(id);
        }
    }
}
