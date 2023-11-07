namespace Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;

public interface ICommandHandler<in TRequest, TResult>
    where TRequest : ICommand<TResult>
    where TResult : class
{
    Task<TResult> Handle(TRequest command, CancellationToken token = default);
}
