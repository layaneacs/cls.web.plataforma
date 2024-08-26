
namespace cls.web.plataforma.Model.Auth;

public class AuthResponse
{
    public AuthData? data { get; set; }
}

public class AuthData
{
    public string token { get; set; } = string.Empty;
}
