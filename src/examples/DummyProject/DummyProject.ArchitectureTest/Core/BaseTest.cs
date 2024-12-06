using DummyProject.Api.Controllers;
using DummyProject.Bll;
using DummyProject.Common.Core;
using DummyProject.Dal;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Assembly = System.Reflection.Assembly;

namespace DummyProject.ArchitectureTest.Core;

public abstract class BaseTest
{
    protected static readonly Assembly ApiAssembly = typeof(WeatherForecastController).Assembly;
    protected static readonly Assembly BllAssembly = typeof(IDummyService).Assembly;
    protected static readonly Assembly DalAssembly = typeof(IDummyRepository).Assembly;
    protected static readonly Assembly CommonAssembly = typeof(Error).Assembly;

    protected const string ApiAssemblyName = "DummyProject.Api";
    protected const string BllAssemblyName = "DummyProject.Bll";
    protected const string DalAssemblyName = "DummyProject.Dall";
    protected const string CommonAssemblyName = "DummyProject.Common";
}