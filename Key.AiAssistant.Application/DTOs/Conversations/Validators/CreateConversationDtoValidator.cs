using FluentValidation;
using Key.AiAssistant.Application.Contracts.Persistence;

namespace Key.AiAssistant.Application.DTOs.Conversations.Validators
{
    public class CreateConversationDtoValidator : AbstractValidator<CreateConversationDto>
    {
        public CreateConversationDtoValidator(IPromptRepository promptRepository)
        {
            Include(new IConversationDtoValidator());

            RuleFor(p => p.PromptId)
                .GreaterThan(0)
                .MustAsync(async (id, _) => await promptRepository.Exists(id))
                .WithMessage("{PropertyName} does not exist.");
        }
    }
}
