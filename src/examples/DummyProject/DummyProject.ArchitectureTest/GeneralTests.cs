using ArchUnitNET.xUnit;
using DummyProject.ArchitectureTest.Core;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace DummyProject.ArchitectureTest;

public class GeneralTests : ArchitectureTestBed
{
    [Fact]
    public void InterfacesName_Should_StartWithAnI()
    {
        Interfaces()
            .Should()
            .HaveNameStartingWith("I")
            .Check(Architecture);
    }
}