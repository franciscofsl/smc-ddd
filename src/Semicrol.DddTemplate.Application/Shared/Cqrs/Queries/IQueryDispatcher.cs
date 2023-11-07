namespace Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQueryResult>(IQuery<TQueryResult> command) where TQueryResult : class;
}
