using EF.Library;
using EF.Library.Entities;
using EF.Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EFController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMainService _service;

        public EFController(ILogger<WeatherForecastController> logger, IMainService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        [Route("/books")]
        public IEnumerable<Book> GetBooks()
        {
            var books =_service.GetAll().ToList();
            return books;

        }
    }
}
