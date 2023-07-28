using FluentValidation;

namespace Key.AiAssistant.Application.DTOs.Conversations.Validators
{
    public class OptimizeResumeChatDtoValidator : AbstractValidator<OptimizeResumeChatDto>
    {
        public OptimizeResumeChatDtoValidator()
        {
            RuleFor(p => p.Resume)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(4000).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(p => p.Vacancy)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(4000).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
        }
    }
}
