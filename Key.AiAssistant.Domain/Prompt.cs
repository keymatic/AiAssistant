using Key.AiAssistant.Domain.Common;

namespace Key.AiAssistant.Domain
{
    public class Prompt : EntityBase
    {
        public string Title { get; set; }
        public string[] Messages { get; set; }
    }
}
