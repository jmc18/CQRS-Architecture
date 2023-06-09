using FluentValidation.Results;

namespace Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("One or more validation errors have occurred.") 
        => Errors = new List<string>();
    public ValidationException(IEnumerable<ValidationFailure>? failures) : this()
        => failures?.ToList()?.ForEach(_ => Errors.Add(_.ErrorMessage));

    public List<string> Errors { get; }

    
}

