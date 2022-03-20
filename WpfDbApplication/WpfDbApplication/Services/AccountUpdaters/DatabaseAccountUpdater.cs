using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.DbContexts;
using WpfDbApplication.DTOs;
using WpfDbApplication.Model;
using WpfDbApplication.Services.Helpers;

namespace WpfDbApplication.Services.AccountUpdaters
{
    public class DatabaseAccountUpdater : IAccountUpdater
    {

        private readonly BankSystemContextFactory dbContextFactory;

        public DatabaseAccountUpdater(BankSystemContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task UpdateAccountMoney(string uuid, decimal money)
        {
            using (BankSystemContext context = dbContextFactory.CreateDbContext())
            {
                if (context.AccountDtos != null)
                {
                    //remove nationality from accountID
                    uuid = uuid.Remove(0, 2);
                    AccountDto accountDto = await context.AccountDtos.FindAsync(uuid);
                    accountDto.Money += money;
                    context.AccountDtos.Update(accountDto);
                    context.SaveChanges();
                }
            }
        }
    }
}
