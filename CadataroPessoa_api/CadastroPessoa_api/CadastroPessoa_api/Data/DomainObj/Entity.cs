using System;

namespace CadastroPessoa_api.Data.DomainObj
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
