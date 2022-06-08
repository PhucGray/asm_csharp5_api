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
    public class FoodsController : ControllerBase
    {
        public IFood _food;

        public FoodsController(IFood food)
        {
            _food = food;
        }

        // GET api/foods
        [HttpGet]
        public async Task<IEnumerable<FoodModel>> GetAll()
        {
            return await _food.GetAll();
        }

        // GET api/foods/3
        [HttpGet("{id}")]
        public async Task<FoodModel> GetById(int id)
        {
            return await _food.GetById(id);
        }

        // POST api/foods
        [HttpPost]
        public async Task<FoodModel> Add(IFormCollection formData)
        {
            return await _food.Add(formData);
        }

        // PUT api/foods/3
        [HttpPut("{id}")]
        public async Task<FoodModel> Update(IFormCollection formData, int id)
        {
            return await _food.Update(formData, id);
        }

        // DELETE api/foods/4
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _food.Delete(id);
        }
    }
}
