using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.DbContexts;
using WpfDbApplication.DTOs;
using WpfDbApplication.Model;
using WpfDbApplication.Services.Helpers;

namespace WpfDbApplication.Services.AccountConflictValidators
{
    public class DatabaseAccountConflictValidator : IAccountConflictValidator
    {

        private readonly BankSystemContextFactory dbContextFactory;

        public DatabaseAccountConflictValidator(BankSystemContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<Account> GetConflictingAccount(Account account)
        {
            using(BankSystemContext context = dbContextFactory.CreateDbContext())
            {
                AccountDto AccountDto = await context.AccountDtos
                    .Where(r => r.Nationality == account.accountID.state)
                    .Where(r => r.Uuid == account.accountID.uuid)
                    .FirstOrDefaultAsync();



                if (AccountDto == null)
                {
                    return null;
                }

                return GeneralHelper.ToAccount(AccountDto);
            }
            
        }
    }
}
