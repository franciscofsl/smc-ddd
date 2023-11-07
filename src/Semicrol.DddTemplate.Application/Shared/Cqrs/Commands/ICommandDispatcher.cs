namespace Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommandResult>(ICommand<TCommandResult> command) where TCommandResult : class;
}
