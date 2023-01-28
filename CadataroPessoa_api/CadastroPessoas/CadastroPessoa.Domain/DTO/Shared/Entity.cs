using System;

namespace CadastroPessoa.Domain.DTO.Entities
{
    public class Entity
    {
        public virtual Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
