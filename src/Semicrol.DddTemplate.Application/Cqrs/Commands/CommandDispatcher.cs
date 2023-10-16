namespace Semicrol.DddTemplate.Application.Cqrs.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TCommandResult> Dispatch<TCommandResult>(ICommandRequest<TCommandResult> commandRequest) where TCommandResult : class
    {
        var type = typeof(ICommandHandler<,>).MakeGenericType(commandRequest.GetType(), typeof(TCommandResult));
        dynamic handler = _serviceProvider.GetService(type);
        CancellationToken token = default;
        return await handler.Handle((dynamic)commandRequest, token);
    }
}
