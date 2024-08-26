using cls.web.plataforma.Data.Interface;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace cls.web.plataforma.Data.Service;

public class SessionContext : ISessionContext
{
    private readonly ProtectedSessionStorage _sessionStorage;
    private const string USER_SESSION = "user_session";
    public SessionContext(ProtectedSessionStorage protectedSessionStorage)
    {
        _sessionStorage = protectedSessionStorage;
    }

    public string TokenSession { get; private set; } = string.Empty;
    public async Task<string?> Get()
    {
        try
        {
            var result = await _sessionStorage.GetAsync<string>(USER_SESSION);
            return result.Value;
        }
        catch
        {
            return string.Empty;
        }
    }
    public async Task Set(string tokenSession)
    {
        TokenSession = tokenSession;
        await _sessionStorage.SetAsync(USER_SESSION, tokenSession);
    }
    public async Task Clear()
    {
        TokenSession = string.Empty;
        await _sessionStorage.DeleteAsync(USER_SESSION);
    }
}
