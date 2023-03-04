namespace CadastroPessoa.Domain.Entities
{
    public class Pessoa : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Nacionalidade { get; set; }
        public string CEP { get; set; }
        public string Uf { get; set; }
        public string Localidade { get; set; }
        public string Logradouro { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
