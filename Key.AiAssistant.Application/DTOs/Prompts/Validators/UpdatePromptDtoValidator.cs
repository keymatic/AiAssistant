using FluentValidation;

namespace Key.AiAssistant.Application.DTOs.Prompts.Validators
{
    public class UpdatePromptDtoValidator : AbstractValidator<PromptDto>
    {
        public UpdatePromptDtoValidator()
        {
            Include(new IPromptDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is not set");
        }
    }
}
