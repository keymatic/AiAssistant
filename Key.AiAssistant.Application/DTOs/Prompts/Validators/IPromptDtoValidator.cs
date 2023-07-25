using FluentValidation;

namespace Key.AiAssistant.Application.DTOs.Prompts.Validators
{
    public class IPromptDtoValidator : AbstractValidator<IPromptDto>
    {
        public IPromptDtoValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Messages)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(t => t != null && t.All(item => !string.IsNullOrWhiteSpace(item)))
                .WithMessage("Please fill {PropertyName} with non-empty items.");
        }
    }
}
