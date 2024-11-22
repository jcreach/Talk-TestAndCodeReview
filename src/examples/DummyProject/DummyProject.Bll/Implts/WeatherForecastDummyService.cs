using System;
using System.Collections.Generic;
using System.Linq;
using DummyProject.Common;
using DummyProject.Common.Core;
using DummyProject.Common.Weather;
using Microsoft.Extensions.Logging;

namespace DummyProject.Bll.Implts;

public sealed class WeatherForecastDummyService(ILogger<WeatherForecastDummyService> logger) : IDummyServices
{
    private readonly ILogger _logger = logger;

    private readonly string[] _summaries =
    [
        "Freezing monday", "Bracing tuesday", "Chilly wednesday", "Cool thursday", "Mild friday", "Warm saturday", "Balmy sunday"
    ];
    
    public string Name => "WeatherForecast";

    public IEnumerable<WeatherForecast> GetWeatherForecast()
    {
        this._logger.LogDebug("GetWeatherForecast used !");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = _summaries[Random.Shared.Next(_summaries.Length)]
            });
    }

    public Result<WeatherForecast> GetWeatherForecastByDayOfWeek(DaysOfWeek dayOfWeek)
    {
        int selectedDay = (int)dayOfWeek;
        
        this._logger.LogDebug($"GetWeatherForecastByDayOfWeek - selected day is {dayOfWeek}, index :{selectedDay}");
        
        if (selectedDay < 0 || selectedDay >= _summaries.Length)
        {
            this._logger.LogError("Selected day is out of range.");
            return Result<WeatherForecast>.Failure(WeatherForecastErrors.OutOfWeekRange);
        }

        var dayForecast = new WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(selectedDay)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = _summaries[selectedDay]
        };
        
        return Result<WeatherForecast>.Success(dayForecast);
    }
}