using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Domain.Abstraction
{
    public abstract class Entity
    {
        public Entity() { }

        public Entity(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
        public DateTime CreatedAt{ get; set; }
        public DateTime? UpdatedAt{ get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
