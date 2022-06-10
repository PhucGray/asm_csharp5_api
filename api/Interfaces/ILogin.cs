using api.Models;
using api.Models.OtherModels;
using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface ILogin
    {
        Task<dynamic> Login(LoginModel customerLogin);
    }
}
