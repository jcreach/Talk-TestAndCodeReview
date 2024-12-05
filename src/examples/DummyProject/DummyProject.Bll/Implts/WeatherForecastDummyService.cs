using DummyProject.Common;
using DummyProject.Common.Core;
using DummyProject.Common.Weather;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DummyProject.Bll.Implts;

public sealed class WeatherForecastDummyService(ILogger<WeatherForecastDummyService> logger) : IDummyService
{
    private readonly ILogger _logger = logger;

    private readonly string[] _summaries =
    [
        "Freezing monday", "Bracing tuesday", "Chilly wednesday", "Cool thursday", "Mild friday", "Warm saturday", "Balmy sunday"
    ];

    public string Name => "WeatherForecast";

    public IEnumerable<WeatherForecastEntity> GetWeatherForecast()
    {
        _logger.LogDebug("GetWeatherForecast used !");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecastEntity
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[Random.Shared.Next(_summaries.Length)]
        });
    }

    public Result<WeatherForecastEntity> GetWeatherForecastByDayOfWeek(DaysOfWeek dayOfWeek)
    {
        int selectedDay = (int)dayOfWeek;

        _logger.LogDebug($"GetWeatherForecastByDayOfWeek - selected day is {dayOfWeek}, index :{selectedDay}");

        if (selectedDay < 0 || selectedDay >= _summaries.Length)
        {
            _logger.LogError("Selected day is out of range.");
            return Result<WeatherForecastEntity>.Failure(WeatherForecastErrors.OutOfWeekRange);
        }

        var dayForecast = new WeatherForecastEntity()
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(selectedDay)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[selectedDay]
        };

        return Result<WeatherForecastEntity>.Success(dayForecast);
    }
}