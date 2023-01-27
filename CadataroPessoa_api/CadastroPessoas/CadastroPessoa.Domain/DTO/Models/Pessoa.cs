using System.ComponentModel.DataAnnotations;

namespace CadastroPessoa.Domain.DTO.Models
{
    public class Pessoa: Entity
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
        public string Uf { get; set; }

        [Required]
        public string Localidade { get; set; }

        [Required]
        public string Logradouro { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Telefone { get; set; }
    }
}
