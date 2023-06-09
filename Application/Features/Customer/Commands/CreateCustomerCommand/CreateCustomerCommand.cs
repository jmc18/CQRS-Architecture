using Application.Wrappers;
using MediatR;

namespace Application.Features.Customer.Commands.CreateCustomerCommand;

public class CreateCustomerCommand : SaveAccountRequest<ClientDetailsVm>
{ }

