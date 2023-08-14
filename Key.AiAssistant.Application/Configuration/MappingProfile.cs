using AutoMapper;
using Key.AiAssistant.Application.DTOs;
using Key.AiAssistant.Application.DTOs.Conversations;
using Key.AiAssistant.Application.DTOs.Messages;
using Key.AiAssistant.Application.DTOs.Prompts;
using Key.AiAssistant.Domain;

namespace Key.AiAssistant.Application.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Prompt, PromptDto>().ReverseMap();
            CreateMap<Prompt, CreatePromptDto>().ReverseMap();
            CreateMap<Conversation, ConversationDto>().ReverseMap();
            CreateMap<Conversation, CreateConversationDto>().ReverseMap();
            CreateMap<Conversation, ConversationListDto>()
                .ForMember(dest => dest.PromptName, e => e.MapFrom(s => s.Prompt == null ? null : s.Prompt.Title));
            CreateMap<Message, MessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
        }
    }
}
