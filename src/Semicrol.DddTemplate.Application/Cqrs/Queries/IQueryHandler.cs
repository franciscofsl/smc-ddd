namespace Semicrol.DddTemplate.Application.Cqrs.Queries;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : IQueryRequest<TResult>
    where TResult : class
{
    Task<TResult> Handle(TQuery command, CancellationToken cancellationToken = default);
}
