using FluentValidation;
using MediatR;

namespace Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        =>_validators = validators;
        

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators?.Any() ?? false)
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults =
                    await Task.WhenAll(_validators.Select(_ => _.ValidateAsync(context, cancellationToken)));
                var failures = validationResults?.SelectMany(_ => _.Errors).Where(_ => _ != null).ToList();

                if (failures?.Count != 0)
                    throw new Exceptions.ValidationException(failures);
            }
            return await next();
        }
    }
}
