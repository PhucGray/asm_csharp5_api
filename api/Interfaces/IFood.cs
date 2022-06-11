using api.Models;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IFood
    {
        Task<dynamic> GetAll();
        Task<dynamic> GetById(int id);
        Task<dynamic> Add(IFormCollection formData);
        Task<dynamic> Update(IFormCollection formData, int id);
        Task<dynamic> Delete(int id);
    }
}
