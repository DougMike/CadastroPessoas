using CadastroPessoa.Domain.DTO.Entities;

namespace CadastroPessoa.Domain.DTO
{
    public class File: Entity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
    }
}
