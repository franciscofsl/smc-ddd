namespace Semicrol.DddTemplate.Architecture.Tests;

public class CoreTest
{
    [Fact]
    public void Core_Should_Not_Have_Dependency_Of_Other_Projects()
    {
        var assembly = typeof(Core.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            Namespaces.Application,
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
}