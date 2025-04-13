using TRAODOITAILIEU.BusinessLayer.DTOs;

namespace TRAODOITAILIEU.BusinessLayer.Interfaces
{
    public interface IAccountService
    {
        UserDTO Register(RegisterRequest request);
        UserDTO Login(LoginRequest reuquest);
    }
}
