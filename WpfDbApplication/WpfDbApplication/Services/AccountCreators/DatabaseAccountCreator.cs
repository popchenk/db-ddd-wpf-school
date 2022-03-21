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
                CardDto cardDto = ToCardDto(account.card);
                context.CardDtos.Add(cardDto);
                //we need to save it so the db will generate pk
                await context.SaveChangesAsync();
                AccountDto AccountDto = ToAccountDto(account, cardDto.id);
                context.AccountDtos.Add(AccountDto);
                await context.SaveChangesAsync();
            }
        }

        private AccountDto ToAccountDto(Account account, int cardId)
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

        private CardDto ToCardDto(Card card)
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
