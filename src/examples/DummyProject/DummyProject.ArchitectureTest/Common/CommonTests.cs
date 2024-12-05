using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using DummyProject.ArchitectureTest.Core;
using DummyProject.Common.Core;
using Microsoft.AspNetCore.Mvc;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace DummyProject.ArchitectureTest.Common;

public class CommonTests : ArchitectureTestBed
{
    [Fact]
    public void Entities_Should_Be_WellNamed_And_InheritFromEntityBaseClass()
    {
        var inheritanceRule = Classes()
            .That()
            .HaveNameEndingWith("Entity")
            .Should()
            .BeAssignableTo(typeof(Entity));

        var entityClassNameRule = Classes()
            .That()
            .AreAssignableTo(typeof(Entity))
            .Should()
            .HaveNameEndingWith("Entity");
            
        inheritanceRule.And(entityClassNameRule).Check(Architecture);
    }
}