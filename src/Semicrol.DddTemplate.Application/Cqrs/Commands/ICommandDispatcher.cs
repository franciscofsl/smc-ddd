namespace Semicrol.DddTemplate.Application.Cqrs.Commands;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommandResult>(ICommandRequest<TCommandResult> commandRequest) where TCommandResult : class;
}
