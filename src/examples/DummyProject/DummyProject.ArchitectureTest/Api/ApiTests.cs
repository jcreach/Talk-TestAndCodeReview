using ArchUnitNET.xUnit;
using DummyProject.ArchitectureTest.Core;
using Microsoft.AspNetCore.Mvc;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace DummyProject.ArchitectureTest.Api;

public class ApiTests : ArchitectureTestBed
{
    [Fact]
    public void Controllers_Should_InheritFromControllerBase()
    {
        Classes()
            .That()
            .AreAssignableTo(typeof(ControllerBase))
            .Should()
            .HaveNameEndingWith("Controller")
            .Check(Architecture);
    }

    [Fact]
    public void ControllersClassName_Should_EndWithController()
    {
        Classes()
            .That()
            .ResideInNamespace($"{ApiAssemblyName}.Controllers")
            .Should()
            .HaveNameEndingWith("Controller")
            .Check(Architecture);
    }

    [Fact]
    public void Controllers_Should_BeInCorrectLayer()
    {
        Classes()
            .That()
            .Are(ControllersClasses)
            .Should()
            .Be(ApiLayer)
            .Check(Architecture);
    }
}