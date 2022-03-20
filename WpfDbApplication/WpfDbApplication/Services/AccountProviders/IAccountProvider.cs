using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Model;

namespace WpfDbApplication.Services.AccountProviders
{
    public interface IAccountProvider
    {

        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountByUuid(string uuid);

    }
}
