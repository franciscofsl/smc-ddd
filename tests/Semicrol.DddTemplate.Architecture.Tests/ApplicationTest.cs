using Semicrol.DddTemplate.Application.Shared.Cqrs.Commands;
using Semicrol.DddTemplate.Application.Shared.Cqrs.Queries;
using Semicrol.DddTemplate.Core.Shared.Events;

namespace Semicrol.DddTemplate.Architecture.Tests;

public class ApplicationTest
{
    [Fact]
    public void Application_Should_Not_Have_Dependency_On_Other_Projects()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            Namespaces.Infrastructure,
            Namespaces.Api
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        testResult.IsSuccessful.ShouldBeTrue();
    }

    #region Commands

    [Fact]
    public void ICommand_Implementations_Should_End_With_Command()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();

        result.FailingTypeNames.ShouldBeNull();
    }

    [Fact]
    public void ICommandHandler_Implementations_Should_End_With_CommandHandler()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        result.FailingTypeNames.ShouldBeNull();
    }

    #endregion

    #region Queries

    [Fact]
    public void IQuery_Implementations_Should_End_With_Query()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();

        result.FailingTypeNames.ShouldBeNull();
    }

    [Fact]
    public void IQueryHandler_Implementations_Should_End_With_QueryHandler()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        result.FailingTypeNames.ShouldBeNull();
    }

    #endregion

    #region Events

    [Fact]
    public void IDomainEventHandler_Implementations_Should_End_With_EventHandler()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IDomainEventHandler<>))
            .Should()
            .HaveNameEndingWith("EventHandler")
            .GetResult();

        result.FailingTypeNames.ShouldBeNull();
    }

    #endregion
}