using cls.web.plataforma.Model;

namespace cls.web.plataforma.Data.Interface
{
    public interface IPessoaService
    {
        Task<Pessoa[]> Get();
        Task<Pessoa> GetById(string id);
        Task<bool> Delete(string? id);
        Task<bool> Save(Pessoa pessoa);
        Task<bool> Update(string id, Pessoa pessoa);
    }
}
