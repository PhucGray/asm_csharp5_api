using api.Interfaces;
using api.Models;
using api.Models.OtherModels;
using api.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
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

        [HttpGet]
        [Route("profile")]
        public async Task<dynamic> GetProfile([FromHeader] string authorization)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var token = headerValue.Parameter;

                return await _auth.GetProfile(token);
            }

            return new { Success = false, Message = "Vui lòng cung cấp token" };
        }

        [HttpPut]
        [Route("update-password")]
        public async Task<dynamic> UpdatePassword([FromHeader] string authorization
                                                , UpdatePasswordReqModel updatePasswordReq)
        {
            if (AuthenticationHeaderValue.TryParse(authorization, out var headerValue))
            {
                var token = headerValue.Parameter;

                return await _auth.UpdatePassword(token, updatePasswordReq);
            }

            return new { Success = false, Message = "Vui lòng cung cấp token" };
        }
    }
}
