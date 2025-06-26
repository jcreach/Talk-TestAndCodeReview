using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using DummyProject.ArchitectureTest.Core;
using DummyProject.Bll;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace DummyProject.ArchitectureTest.Bll;

public class BllTests : ArchitectureTestBed
{
    [Fact]
    public void Services_Should_BeSealed()
    {
        Classes()
            .That()
            .Are(ServicesClasses)
            .Should()
            .BeSealed()
            .Check(Architecture);
    }

    [Fact]
    public void IDummyServices_Implementations_Should_EndByService()
    {
        Classes()
            .That()
            .Are(ServicesClasses)
            .Should()
            .HaveNameEndingWith("Service")
            .Check(Architecture);
    }

    [Fact]
    public void Services_Should_BeInCorrectLayer()
    {
        Classes()
            .That()
            .Are(ServicesClasses)
            .Should()
            .Be(BllLayer)
            .Check(Architecture);
    }
}