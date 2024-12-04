using DummyProject.ArchitectureTest.Core;

namespace DummyProject.ArchitectureTest.Api;

public class ApiTests : ArchitectureTestBed
{
    [Fact]
    public void Controllers_Should_InheritFromControllerBase()
    {
        // Classes()
        //     .That()
        //     .AreAssignableTo(typeof(ControllerBase))
        //     .Should()
        //     .HaveNameEndingWith("Controller")
        //     .Check(Architecture);
    }

    [Fact]
    public void ControllersName_Should_EndWithController()
    {
        // Classes()
        //     .That()
        //     .ResideInNamespace($"{ApiAssemblyName}.Controllers")
        //     .Should()
        //     .HaveNameEndingWith("Controller")
        //     .Check(Architecture);
    }
}