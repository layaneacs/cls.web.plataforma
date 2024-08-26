
namespace cls.web.plataforma.Model;

public class Notification<T>
{
    public T? Data { get; private set; }
    public bool IsSucess { get; private set; }
    public string Message { get; private set; } = string.Empty;

    public void Sucesso(T value)
    {
        IsSucess = true;
        Data = value;
        Message = string.Empty;
    }

    public void Erro(string errorMessage)
    {
        IsSucess = false;
        Data = default;
        Message = errorMessage;
    }
}
