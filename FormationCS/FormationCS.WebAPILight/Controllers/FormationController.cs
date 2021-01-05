using FormationCS.Adapters;
using FormationCS.Contexts;
using FormationCS.DTOs;
using FormationCS.Entities;
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

        [HttpGet]
        [Route("api/account/{id:long}")]
        public AccountDTO GetAccountDTOById(long id)
        {
            return _service.GetAccountById(id).ToDTO();
        }

        [HttpGet]
        [Route("api/account/bycustomer/{id:long}")]
        public List<AccountDTO> GetAccountsByCustomerId(long id)
        {
            return _service.GetAccountsByCustomerId(id).ToDTOs().ToList();
        }

        [HttpGet]
        [Route("api/account/deposit/{amount:double}/{accountId:long}")]
        public AccountDTO Deposit(long accountId, double amount)
        {
            try
            {
                Account account = _service.GetAccountById(accountId);
                if(account == null)
                {
                    throw new BankException("The Account does not exist");
                }
                _service.Deposit(account, amount);
                _service.Save();
                return account.ToDTO();
            }
            catch(BankException)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("api/bank")]
        public BankDTO CreateBank(BankDTO bank)
        {
            BankDTO dto = _service.CreateBank(bank.Name).ToDTO();
            _service.Save();
            return dto;
        }

        [HttpPut]
        [Route("api/bank/{id:long}")]
        public BankDTO UpdateBank(BankDTO bank)
        {
            //BankDTO dto = _service.UpdateBank(bank.Name).ToDTO();
            _service.Save();
            return bank;
        }

        [HttpPut]
        [Route("api/bank/{id:long}")]
        public bool DeleteBank(long id)
        {
            //_service.DeleteBank(id);
            _service.Save();
            return true;
        }


    }
}
