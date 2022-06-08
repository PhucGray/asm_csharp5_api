using api.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IFood
    {
        IEnumerable<FoodModel> GetAll();
        FoodModel GetById(int id);
        Task<dynamic> Add(IFormCollection formData);
        FoodModel Update(FoodModel food);
        void Delete(int id);
    }
}
