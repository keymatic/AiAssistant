using FluentValidation.Results;

namespace Key.AiAssistant.Application.Exceptions
{
    public class ModelValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new();

        public ModelValidationException(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}
