using AutoMapper;
using Key.AiAssistant.Application.Contracts.ChatBot;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Conversations.Validators;
using Key.AiAssistant.Application.Exceptions;
using Key.AiAssistant.Application.Features.Conversations.Requests.Commands;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Handlers.Commands
{
    public class CreateConversationHandler : IRequestHandler<CreateConversationCommand, int>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IMapper _mapper;
        private readonly IPromptRepository _promptRepository;
        private readonly IChatBotClient _chatBotClient;

        public CreateConversationHandler(IConversationRepository conversationRepository, IMapper mapper,
            IPromptRepository promptRepository, IChatBotClient chatBotClient)
        {
            _conversationRepository = conversationRepository;
            _promptRepository = promptRepository;
            _mapper = mapper;
            _chatBotClient = chatBotClient;
        }

        public async Task<int> Handle(CreateConversationCommand command, CancellationToken cancellationToken)
        {
            await ValidateCommand(command, cancellationToken);

            var prompt = await _promptRepository.Get(command.ConversationDto.PromptId);

            var conversation = await _chatBotClient.SendAsync(prompt.Messages, cancellationToken);
            conversation.Title = command.ConversationDto.Title;
            conversation = await _conversationRepository.Add(conversation);
            return conversation.Id;
        }

        private async Task ValidateCommand(CreateConversationCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateConversationDtoValidator(_promptRepository);
            var validationResult = await validator.ValidateAsync(command.ConversationDto, cancellationToken);
            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);
        }
    }
}
