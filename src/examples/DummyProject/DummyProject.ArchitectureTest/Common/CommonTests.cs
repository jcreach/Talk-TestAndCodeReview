using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using DummyProject.ArchitectureTest.Core;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace DummyProject.ArchitectureTest.Common;

public class CommonTests : ArchitectureTestBed
{
    private const string AssemblyBaseName = "DummyProject";
    private const string ApiAssemblyName = $"{AssemblyBaseName}.Api";
    private const string BllAssemblyName = $"{AssemblyBaseName}.Bll";
    private const string DalAssemblyName = $"{AssemblyBaseName}.Dal";
    private const string CommonAssemblyName = $"{AssemblyBaseName}.Common";
    
    private readonly Architecture _architecture = new ArchLoader().LoadAssemblies(
        System.Reflection.Assembly.Load(ApiAssemblyName),
        System.Reflection.Assembly.Load(BllAssemblyName),
        System.Reflection.Assembly.Load(DalAssemblyName),
        System.Reflection.Assembly.Load(CommonAssemblyName)
    ).Build();

    private readonly IObjectProvider<IType> ApiLayer = Types()
        .That()
        .ResideInAssembly(ApiAssemblyName)
        .As("Dummy api Layer");
    
    private readonly IObjectProvider<IType> DalLayer = Types()
        .That()
        .ResideInAssembly(DalAssemblyName)
        .As("Dummy dal Layer");

    private readonly IObjectProvider<IType> CommonLayer = Types()
        .That()
        .ResideInAssembly(CommonAssemblyName)
        .As("Dummy common Layer");


    [Fact]
    public void CommonLayerShouldNotBeDependentOnOthers()
    {
        // Arrange
        
        // Act
        
        
        /*var rules = Types()
            .That()
            .Are(CommonLayer)
            .Should().NotDependOnAny(ApiLayer).Because("it's forbiden");
        
        // Assert
        
        rules.Check(_architecture);
        */
        
        IArchRule exampleLayerShouldNotAccessForbiddenLayer = Types().That().Are(CommonLayer).Should()
            .NotDependOnAny(ApiLayer).Because("it's forbidden");
        
        exampleLayerShouldNotAccessForbiddenLayer.Check(_architecture);
    }
}