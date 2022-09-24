using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa_API.Models
{
    public class Pessoa : Entity
    {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Sobrenome { get; set; }
        [Required]
        public string Nacionalidade { get; set; }
        [Required]
        public int CEP { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Logradouro { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Telefone { get; set; }
    }
}
