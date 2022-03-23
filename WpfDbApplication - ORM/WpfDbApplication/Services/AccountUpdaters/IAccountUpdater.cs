using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.Model;

namespace WpfDbApplication.Services.AccountUpdaters
{
    public interface IAccountUpdater
    {

        Task UpdateAccountMoney(string uuid, decimal money);

    }
}
