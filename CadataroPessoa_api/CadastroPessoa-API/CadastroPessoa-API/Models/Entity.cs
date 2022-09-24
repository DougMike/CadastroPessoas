using System;

namespace CadastroPessoa_API.Models
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
