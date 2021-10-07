using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyApi.Controllers
{
    [ApiController]  // Diciamo al progetto di considerare la classe wFC 
    [Route("[controller]")] // Questo controller verrà raggiunto grazie al suo nome
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        // private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet("get")]  // Attributi, sono delle classi che funziano in un certo modo, e risponde solo alle 
                          // chiamate con /get,
                          // cosi posso configurare lo specifico percorso a cui dovrà rispondere questo metodo

        //public WeatherForecast Get()
        //{

        //    return new WeatherForecast { Summary = "Pippo", TemperatureC = 30 };

        //   // return "Hello Word";  // restituisco un oggetto, esso poi verrà convertito nel formato jaison
        //}

        //List<string> nomi = new List<string> { "Mario", "Pippo", "Alessia" };
        //EnvironmentVariableTarget lunghezzaNomi = nomi.Select(n => n.Length);
        //foreach(var l in lunghezzaNomi)
        //{
        //        console.WriteLine(l);

        //}


        // SELECT  FA IN MODO DI GENERARE UN NUOVO INUMERABLE
        // A PARTIRE DA UNO ESISTENTE, SFRUTTANDO LA LAMBDA EXPRESSION PASSATA COME
        //PARAMETRO



        public IActionResult Get()
        {
            return Ok(new WeatherForecast { Summary = "Pippo", TemperatureC = 30 });




        }

    }


}

