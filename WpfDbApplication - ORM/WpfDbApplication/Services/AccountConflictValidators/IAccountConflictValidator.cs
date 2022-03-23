using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Model;

namespace WpfDbApplication.Services.AccountConflictValidators
{
    public interface IAccountConflictValidator
    {

        Task<Account> GetConflictingAccount(Account account);

    }
}
