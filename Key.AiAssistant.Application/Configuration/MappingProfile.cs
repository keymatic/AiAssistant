using AutoMapper;
using Key.AiAssistant.Application.DTOs;
using Key.AiAssistant.Domain;

namespace Key.AiAssistant.Application.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Prompt, PromptDto>().ReverseMap();
            CreateMap<Conversation, ConversationDto>().ReverseMap();
            CreateMap<Message, MessageDto>().ReverseMap();
        }
    }
}
