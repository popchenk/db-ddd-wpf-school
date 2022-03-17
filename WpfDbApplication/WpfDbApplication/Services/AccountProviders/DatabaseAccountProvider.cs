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

namespace WpfDbApplication.Services.AccountProviders
{
    public class DatabaseAccountProvider : IAccountProvider
    {
        private readonly BankSystemContextFactory dbContextFactory;

        public DatabaseAccountProvider(BankSystemContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            using (BankSystemContext context = dbContextFactory.CreateDbContext())
            {
                if(context.AccountDtos != null)
                {
                    IEnumerable<AccountDto> AccountDtos = await context.AccountDtos.ToListAsync();
                    if(AccountDtos != null && AccountDtos.Select(r => GeneralHelper.ToAccount(r)) != null)
                    {
                        return AccountDtos.Select(r => GeneralHelper.ToAccount(r));
                    }
                }
                return new List<Account>();
            }



        }

    }
}
