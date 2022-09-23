using FluentValidation.Results;

namespace LinearSistemas.CanaisVendas.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException()
            : base("Um ou mais erros de validação foram encontrados.")
        {
            Errors = new Dictionary<string, string[]>();
            
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
