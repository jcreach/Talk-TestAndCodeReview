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
            .ImplementInterface(typeof(IDummyServices))
            .Should()
            .BeSealed()
            .Check(Architecture);
    }

    [Fact]
    public void IDummyServices_Implementations_Should_EndByService()
    {
        Classes()
            .That()
            .ImplementInterface(typeof(IDummyServices))
            .Should()
            .HaveNameEndingWith("Service")
            .Check(Architecture);
    }
}