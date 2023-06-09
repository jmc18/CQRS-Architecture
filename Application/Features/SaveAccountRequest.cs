using Application.Wrappers;
using MediatR;

namespace Application.Features;
public abstract class SaveAccountRequest<T> : IRequest
{
    public required T Data { get; set; }
}

