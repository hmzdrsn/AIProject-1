using AIProject.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Domain.Entities
{
    public  class Prompt : Entity
    {
        public string PromptText { get; set; }
        public string PromptName { get; set; }
        public List<Chat> Chats { get; set; }


        // New chat -> kategori (prompt) -> (a1 - b2) Degree -> chat messages ==>
    }
}
