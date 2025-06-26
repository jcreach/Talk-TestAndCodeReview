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
        var rule = Types()
            .That()
            .Are(CommonLayer)
            .Should()
            .NotDependOnAny(ApiLayer);

        // Assert
        rule.Check(Architecture);
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
    public void CommonLayer_Should_NotHaveDependencyOnOtherLayer()
    {
        // Act
        var apiLayerRule = Types()
            .That()
            .Are(CommonLayer)
            .Should()
            .NotDependOnAny(ApiLayer);

        var bllLayerRule = Types()
            .That()
            .Are(CommonLayer)
            .Should()
            .NotDependOnAny(BllLayer);

        var dalLayerRule = Types()
            .That()
            .Are(CommonLayer)
            .Should()
            .NotDependOnAny(DalLayer);


        // Assert
        apiLayerRule.And(bllLayerRule).And(dalLayerRule).Check(Architecture);
    }

    [Fact]
    public void DalLayer_Should_NotHaveDependencyOnApiLayerAndBllLayer()
    {
        var apiLayerRule = Types()
            .That()
            .Are(DalLayer)
            .Should()
            .NotDependOnAny(ApiLayer);

        var bllLayerRule = Types()
            .That()
            .Are(DalLayer)
            .Should()
            .NotDependOnAny(BllLayer);

            apiLayerRule.And(bllLayerRule).Check(Architecture);
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