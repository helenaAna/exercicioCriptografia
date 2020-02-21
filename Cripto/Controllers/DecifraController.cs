using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cripto.Business;
using Cripto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cripto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecifraController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DecifraController> _logger;

        public DecifraController(ILogger<DecifraController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Mensagem Get()
        {
           return new DecifraBO().Decifrar();

        }
    }
}
