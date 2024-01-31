using AIProject.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIProject.Domain.Entities
{
    public class Chat : Entity
    {
        public string UserId { get; set; }
        public string PromptId { get; set; }
        public string Subject { get; set;}
        public string CustomPrompt { get; set; }
        public string EnglishDegreeId{ get; set; }
        public EnglishDegree EnglishDegree{ get; set; }
        public User User { get; set; }
        public Prompt Prompt { get; set; }
        public List<ChatMessage> ChatMessages { get; set; }

    }
}
