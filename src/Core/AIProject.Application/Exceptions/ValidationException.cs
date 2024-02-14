using FluentValidation.Results;


namespace AIProject.Application.Exceptions
{
    public class ValidationException :Exception 
    {
        public IDictionary<string, string[]> Errors { get; set; }
        public ValidationException() : base("Bir veya daha fazla Validation hatası oluştu ") 
        {
            Errors = new Dictionary<string,string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }
    }
}
