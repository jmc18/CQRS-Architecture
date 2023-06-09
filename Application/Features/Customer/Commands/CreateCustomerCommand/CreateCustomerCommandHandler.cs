using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.Customer.Commands.CreateCustomerCommand
{
    public class CreateCustomerCommandHandler : SaveCommandHandlerBase<CreateCustomerCommand>
    {
        public CreateCustomerCommandHandler(IMapper mapper, ILogger<CreateCustomerCommand> logger, IMediator mediator) : base(mapper, logger, mediator)
        {
        }
    }
}
