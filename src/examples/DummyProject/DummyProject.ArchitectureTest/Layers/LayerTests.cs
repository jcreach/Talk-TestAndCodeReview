using ArchUnitNET.xUnit;
using DummyProject.ArchitectureTest.Core;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace DummyProject.ArchitectureTest.Layers;

public class LayerTests : ArchitectureTestBed
{
    [Fact]
    public void CommonLayer_Should_NotHaveDependencyOnApiLayer()
    {
        // Act
        var result = Types()
            .That()
            .Are(CommonLayer)
            .Should()
            .NotDependOnAny(ApiLayer);

        // Assert
        result.Check(Architecture);
    }

    [Fact]
    public void CommonLayer_Should_NotHaveDependencyOnBllLayer()
    {
        Types()
            .That()
            .Are(CommonLayer)
            .Should()
            .NotDependOnAny(BllLayer)
            .Check(Architecture);
    }

    [Fact]
    public void CommonLayer_Should_NotHaveDependencyOnDalLayer()
    {
        Types()
            .That()
            .Are(CommonLayer)
            .Should()
            .NotDependOnAny(DalLayer)
            .Check(Architecture);
    }

    [Fact]
    public void DalLayer_Should_NotHaveDependencyOnApiLayer()
    {
        Types()
            .That()
            .Are(DalLayer)
            .Should()
            .NotDependOnAny(ApiLayer)
            .Check(Architecture);
    }

    [Fact]
    public void DalLayer_Should_NotHaveDependencyOnBllLayer()
    {
        Types()
            .That()
            .Are(DalLayer)
            .Should()
            .NotDependOnAny(BllLayer)
            .Check(Architecture);
    }

    [Fact]
    public void BllLayer_Should_NotHaveDependencyOnApiLayer()
    {
        Types()
            .That()
            .Are(BllLayer)
            .Should()
            .NotDependOnAny(ApiLayer)
            .Check(Architecture);
    }
}