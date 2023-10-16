namespace Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<TQueryResult> Dispatch<TQueryResult>(IQueryRequest<TQueryResult> commandRequest) where TQueryResult : class
    {
        var type = typeof(IQueryHandler<,>).MakeGenericType(commandRequest.GetType(), typeof(TQueryResult));
        dynamic handler = _serviceProvider.GetService(type);
        return await handler.Handle((dynamic)commandRequest);
    }
}
