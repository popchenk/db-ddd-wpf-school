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
        public static Account ToAccount(AccountDto dto, CardDto cardDto = null)
        {
            //new Card(cdto.cardNum, cdto.cvv, cdto.expDate)
            return new Account(new AccountID(dto.Nationality, dto.Uuid), dto.Email, (decimal)dto.Money, (cardDto != null) ? new Card(cardDto.cardNum, cardDto.cvv, cardDto.expDate) : null);
        }

    }
}
