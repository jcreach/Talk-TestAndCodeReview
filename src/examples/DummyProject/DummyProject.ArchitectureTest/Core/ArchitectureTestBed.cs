using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace DummyProject.ArchitectureTest.Core;

public abstract class ArchitectureTestBed : BaseTest
{
    protected static readonly Architecture Architecture = new ArchLoader()
        .LoadAssemblies(
            ApiAssembly,
            BllAssembly,
            DalAssembly,
            CommonAssembly
        ).Build();

    protected readonly IObjectProvider<IType> CommonLayer = Types()
        .That()
        .ResideInAssembly(CommonAssembly)
        .As("Common layer");

    protected readonly IObjectProvider<IType> ApiLayer = Types()
        .That()
        .ResideInAssembly(ApiAssembly)
        .As("Api layer");

    protected readonly IObjectProvider<IType> BllLayer = Types()
        .That()
        .ResideInAssembly(BllAssembly)
        .As("Bll layer");

    protected readonly IObjectProvider<IType> DalLayer = Types()
        .That()
        .ResideInAssembly(DalAssembly)
        .As("Dal layer");
}