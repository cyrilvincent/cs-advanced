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

        private readonly IBankService _service;

        // IoC Inversion Of Control = Je ne veux accéder qu'à des interfaces
        // IoD Injection Of Dependency = Factory automatique

        public FormationController(IBankService service)
        {
            _service = service;
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

        [HttpDelete]
        [Route("api/bank/{id:long}")]
        public bool DeleteBank(long id)
        {
            //_service.DeleteBank(id);
            _service.Save();
            return true;
        }

        [HttpPost]
        [Route("api/account")]
        public AccountDTO CreateCustomer(AccountForCreateDTO accountDTO)
        {
            Bank bank = _service.GetBankById(accountDTO.BankId);
            if(bank == null)
            {
                throw new BankException("Bank does not exist");
            }
            Customer customer = _service.GetCustomerById(accountDTO.CustomerId);
            if (customer == null)
            {
                throw new BankException("Customer does not exist");
            }
            Account account = _service.CreateAccount(bank, customer);
            _service.Save();
            return account.ToDTO();
        }

        [HttpDelete]
        [Route("api/account/{id:long}")]
        public bool DeleteAccount(long id)
        {
            _service.DeleteAccountById(id);
            _service.Save();
            return true;
        }


    }
}
