using AIProject.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Domain.Entities
{
    public class EnglishDegree : Entity
    {
        public string Degree { get; set; }
        public List<Chat> Chats{ get; set; }

    }
}
