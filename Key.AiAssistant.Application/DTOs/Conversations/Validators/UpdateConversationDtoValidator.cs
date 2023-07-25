using FluentValidation;

namespace Key.AiAssistant.Application.DTOs.Conversations.Validators
{
    public class UpdateConversationDtoValidator : AbstractValidator<UpdateConversationDto>
    {
        public UpdateConversationDtoValidator()
        {
            Include(new IConversationDtoValidator());

            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} is not set");
        }
    }
}
