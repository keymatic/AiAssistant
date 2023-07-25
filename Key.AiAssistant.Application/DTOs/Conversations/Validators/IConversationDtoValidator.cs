using FluentValidation;

namespace Key.AiAssistant.Application.DTOs.Conversations.Validators
{
    public class IConversationDtoValidator : AbstractValidator<IConversationDto>
    {
        public IConversationDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
