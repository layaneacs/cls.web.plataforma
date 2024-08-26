namespace cls.web.plataforma.Data.Interface;

public interface ISessionContext
{
    public Task<string?> Get();
    public Task Set(string tokenSession);
    public Task Clear();
}
