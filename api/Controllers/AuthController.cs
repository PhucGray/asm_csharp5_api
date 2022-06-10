using api.Interfaces;
using api.Models;
using api.Models.OtherModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuth _auth;

        public AuthController(IAuth auth)
        {
            _auth = auth;
        }

        [HttpPost]
        [Route("login")]
        public async Task<dynamic> Login(LoginModel loginInfo)
        {
            return await _auth.Login(loginInfo);
        }

        [HttpPost]
        [Route("register")]
        public async Task<dynamic> Register(UserModel userRegister)
        {
            return await _auth.Register(userRegister);
        }
    }
}
