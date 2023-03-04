using System;

namespace CadastroPessoa.Domain.Entities
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
