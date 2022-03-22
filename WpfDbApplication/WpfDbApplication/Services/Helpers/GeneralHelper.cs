using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static AccountDto ToAccountDto(Account account, int cardId)
        {
            return new AccountDto()
            {
                //retype this to nationality
                Nationality = account.accountID.state,
                Uuid = account.accountID.uuid,
                Email = account.email,
                Money = account.money,
                CardId = cardId
            };
        }

        public static CardDto ToCardDto(Card card)
        {
            return new CardDto()
            {
                cardNum = card.cardNum,
                cvv = card.cvv,
                expDate = card.expiration
            };
        }

    }
}
