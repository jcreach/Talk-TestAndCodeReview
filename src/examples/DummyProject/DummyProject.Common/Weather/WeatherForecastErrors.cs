using DummyProject.Common.Core;

namespace DummyProject.Common.Weather;

public static class WeatherForecastErrors
{
    public static readonly Error OutOfWeekRange = new("WeatherForecastError.OutOfWeekRange", "Selected day is out of range.");
}