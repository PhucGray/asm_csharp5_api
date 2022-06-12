using api.Models;
using api.Models.OtherModels;
using api.Models.Request;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IAuth
    {
        Task<dynamic> Login(LoginModel loginInfo);
        Task<dynamic> Register(UserModel customerRegister);
        Task<dynamic> GetProfile(string token);
        Task<dynamic> UpdatePassword(string token, UpdatePasswordReqModel updatePasswordReq);
    }
}
