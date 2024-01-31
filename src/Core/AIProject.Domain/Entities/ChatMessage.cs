using AIProject.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Domain.Entities
{
    public class ChatMessage : Entity
    {
        public string ChatId { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public Chat Chat { get; set; }
    }
}
