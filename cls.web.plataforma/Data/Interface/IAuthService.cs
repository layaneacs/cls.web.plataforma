using cls.web.plataforma.Model;
using cls.web.plataforma.Model.Auth;

namespace cls.web.plataforma.Data.Interface;
public interface IAuthService
{
    Task<Notification<AuthResponse>> Login(string username, string password);
}
