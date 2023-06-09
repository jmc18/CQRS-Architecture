using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features;

public class SaveCommandHandlerBase<T> : IRequestHandler<T> where T : IRequest
{
    public IMediator Mediator { get; }
    protected readonly IMapper Mapper;

    protected readonly ILogger<T> Logger;

    public SaveCommandHandlerBase(IMapper mapper, ILogger<T> logger, IMediator mediator)
    {
        Mediator = mediator;
        Mapper = mapper;
        Logger = logger;
    }

    public virtual Task<Unit> Handle(T request, CancellationToken cancellationToken)
        => Unit.Task;
}

