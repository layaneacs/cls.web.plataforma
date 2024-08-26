namespace cls.web.plataforma.Model
{
    public class Pessoa
    {
        public string id { get; set; } = string.Empty;
        public string sobrenome { get; set; } = string.Empty;
        public string nome { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string telefone { get; set; } = string.Empty;
        public DateTime dataNascimento { get; set; }
    }
}
