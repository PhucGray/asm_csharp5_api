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
        public IEnumerable<FoodModel> GetAll()
        {
            return _food.GetAll();
        }

        // GET api/foods/3
        [HttpGet("{id}")]
        public FoodModel GetById(int id)
        {
            return _food.GetById(id);
        }

        // POST api/foods
        [HttpPost]
        public async Task<dynamic> Add(IFormCollection formData)
        {
            return await _food.Add(formData);
        }

        // PUT api/foods/3
        [HttpPut("{id}")]
        public FoodModel Update([FromBody] FoodModel food)
        {
            return _food.Update(food);
        }

        // DELETE api/foods/4
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _food.Delete(id);
        }
    }
}
