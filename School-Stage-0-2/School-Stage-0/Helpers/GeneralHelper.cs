using School_Stage_0.DTOs;
using School_Stage_0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.Helpers
{
    public class GeneralHelper
    {

        //cardDto -> dto. cardNum etc
        public static Account ToAccount(AccountDto dto)
        {
            //new Card(cdto.cardNum, cdto.cvv, cdto.expDate)
            return new Account(new AccountID(dto.Nationality, dto.Uuid), dto.Email, (decimal)dto.Money);
        }

        public static AccountDto ToAccountDto(Account account)
        {
            return new AccountDto()
            {
                //retype this to nationality
                Nationality = account.accountID.state,
                Uuid = account.accountID.uuid,
                Email = account.email,
                Money = account.money
            };
        }

    }
}
