using System.Collections.Generic;
using DummyProject.Bll.Implts;
using DummyProject.Common;
using DummyProject.Common.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DummyProject.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger, 
    WeatherForecastDummyService weatherForecastDummyService) : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger = logger;

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecastEntity> Get()
    {
        return weatherForecastDummyService.GetWeatherForecast();
    }

    [HttpGet("{dayOfWeek}", Name = "GetWeatherForecastByDayOfWeek")]
    public ActionResult<WeatherForecastEntity> Get(DaysOfWeek dayOfWeek)
    {
        var dayForecast = weatherForecastDummyService.GetWeatherForecastByDayOfWeek(dayOfWeek);

        if (dayForecast.IsFailure)
            return BadRequest();
        
        return Ok(dayForecast.Value);
    }
    
    [HttpGet("legacy/{dayOfWeek:int}", Name = "GetWeatherForecastByDayOfWeekInt")]
    public ActionResult<WeatherForecastEntity> Get(int dayOfWeek)
    {
        var dayForecast = weatherForecastDummyService.GetWeatherForecastByDayOfWeek((DaysOfWeek)dayOfWeek);

        if (dayForecast.IsFailure)
            return BadRequest($"{dayForecast.Error.Code} - {dayForecast.Error.Description}");
        
        return Ok(dayForecast.Value);
    }
}