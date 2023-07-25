using FluentValidation;

namespace Key.AiAssistant.Application.DTOs.Prompts.Validators
{
    public class CreatePromptDtoValidator : AbstractValidator<CreatePromptDto>
    {
        public CreatePromptDtoValidator()
        {
            Include(new IPromptDtoValidator());
        }
    }
}
