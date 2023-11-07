namespace Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : class
{
    Task<TResult> Handle(TQuery command, CancellationToken cancellationToken = default);
}
