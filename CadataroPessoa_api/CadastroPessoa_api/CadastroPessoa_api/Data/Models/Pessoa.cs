using CadastroPessoa_api.Data.DomainObj;
using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa_api.Data.Models
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
        public string CEP { get; set; }

        [Required]
        public string Estado { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }
    }
}
