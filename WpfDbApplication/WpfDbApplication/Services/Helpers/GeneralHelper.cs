using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.DTOs;
using WpfDbApplication.Model;

namespace WpfDbApplication.Services.Helpers
{
    class GeneralHelper
    {

        //cardDto -> dto. cardNum etc
        public static Account ToAccount(AccountDto dto)
        {
            //new Card(cdto.cardNum, cdto.cvv, cdto.expDate)
            return new Account(new AccountID(dto.Nationality), dto.Email, (decimal)dto.Money, null);
        }

    }
}
