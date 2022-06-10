using api.Models;
using api.Models.OtherModels;
using System.Threading.Tasks;

namespace api.Interfaces
{
    public interface IAuth
    {
        Task<dynamic> Login(LoginModel loginInfo);
        Task<dynamic> Register(UserModel customerRegister);
    }
}
