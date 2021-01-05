using FormationCS.DTOs;
using FormationCS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormationCS.Adapters
{
    public static class Adapters
    {
        public static AccountDTO ToDTO(this Account account)
        {
            return new AccountDTO
            {
                Id = account.Id,
                BankName = account.Bank.Name,
                Name = account.Owner.FirstName ?? "" + " " + account.Owner.LastName,
                Solde = account.Balance
            };
        }

        public static IQueryable<AccountDTO> ToDTOs(this IQueryable<Account> entities)
        {
            return entities.Select(e => e.ToDTO());
        }

        // BankDTO
        // Adapter BankDTO
        // Tester
        // Idem pour AccountDTO
    }
}
