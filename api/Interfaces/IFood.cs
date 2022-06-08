using api.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IFood
    {
        Task<IEnumerable<FoodModel>> GetAll();
        Task<FoodModel> GetById(int id);
        Task<FoodModel> Add(IFormCollection formData);
        Task<FoodModel> Update(IFormCollection formData, int id);
        Task<bool> Delete(int id);
    }
}
