using Key.AiAssistant.Application.Contracts.ChatBot;
using Key.AiAssistant.Application.Contracts.Persistence;
using Key.AiAssistant.Application.DTOs.Conversations.Validators;
using Key.AiAssistant.Application.Exceptions;
using Key.AiAssistant.Application.Features.Conversations.Requests.Commands;
using MediatR;

namespace Key.AiAssistant.Application.Features.Conversations.Handlers.Commands
{
    public class OptimizeResumeHandler : IRequestHandler<OptimizeResumeCommand, int>
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IChatBotClient _chatBotClient;

        public OptimizeResumeHandler(IConversationRepository conversationRepository, IChatBotClient chatBotClient)
        {
            _conversationRepository = conversationRepository;
            _chatBotClient = chatBotClient;
        }

        public async Task<int> Handle(OptimizeResumeCommand command, CancellationToken cancellationToken)
        {
            await ValidateCommand(command, cancellationToken);

            var conversation = await _chatBotClient.OptimizeResumeAsync(command.OptimizeResumeChatDto.Resume,
                command.OptimizeResumeChatDto.Vacancy);

            conversation = await _conversationRepository.Add(conversation);
            return conversation.Id;
        }

        private static async Task ValidateCommand(OptimizeResumeCommand command, CancellationToken cancellationToken)
        {
            var validator = new OptimizeResumeChatDtoValidator();
            var validationResult = await validator.ValidateAsync(command.OptimizeResumeChatDto, cancellationToken);
            if (!validationResult.IsValid)
                throw new ModelValidationException(validationResult);
        }
    }
}
