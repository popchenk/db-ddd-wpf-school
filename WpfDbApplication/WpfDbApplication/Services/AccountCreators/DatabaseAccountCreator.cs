using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.DbContexts;
using WpfDbApplication.DTOs;
using WpfDbApplication.Model;

namespace WpfDbApplication.Services.AccountCreators
{
    public class DatabaseAccountCreator : IAccountCreator
    {
        private readonly BankSystemContextFactory dbContextFactory;

        public DatabaseAccountCreator(BankSystemContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task CreateAccount(Account account)
        {
            using (BankSystemContext context = dbContextFactory.CreateDbContext())
            {
                AccountDto AccountDto = ToAccountDto(account);
                context.AccountDtos.Add(AccountDto);
                await context.SaveChangesAsync();
            }
        }

        private AccountDto ToAccountDto(Account account)
        {
            return new AccountDto()
            {
                //retype this to nationality
                Nationality = account.accountID.state,
                Uuid = account.accountID.uuid,
                Email = account.email,
                Money = account.money,
            };
        }
    }
}
