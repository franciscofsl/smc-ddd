namespace Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;

public class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TCommandResult> Dispatch<TCommandResult>(ICommand<TCommandResult> command) where TCommandResult : class
    {
        var type = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TCommandResult));
        dynamic handler = _serviceProvider.GetService(type);
        CancellationToken token = default;
        return await handler.Handle((dynamic)command, token);
    }
}
