using FormationCS.Adapters;
using FormationCS.Contexts;
using FormationCS.DTOs;
using FormationCS.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormationCS.WebAPILight.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormationController : Controller
    {

        private readonly FormationContext _context = new FormationContext();
        private readonly BankService _service; 

        public FormationController()
        {
            _service = new BankService(_context);
        }

        [HttpGet]
        [Route("api/")]
        public string Ping()
        {
            return "Pong";
        }

        [HttpGet]
        [Route("api/bank/{id:long}")]
        public BankDTO Bank(long id)
        {
            try
            {
                return _service.GetBankById(id).ToDTO();
            }
            catch(NullReferenceException nre)
            {
                return null;
            }
        }

        /*
         * Porter le service (tous sauf create) dans la webapi
         * */


    }
}
