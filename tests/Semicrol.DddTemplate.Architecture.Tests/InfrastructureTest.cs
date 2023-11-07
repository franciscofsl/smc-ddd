namespace Semicrol.DddTemplate.Architecture.Tests;

public class InfrastructureTest
{
    [Fact]
    public void Infrastructure_Should_Not_Have_Dependency_On_Other_Projects()
    {
        var assembly = typeof(Infrastructure.AssemblyReference).Assembly;

        var otherProjects = new[]
        { 
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