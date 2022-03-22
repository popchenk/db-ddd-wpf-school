using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.DTOs;
using WpfDbApplication.Model;
using WpfDbApplication.Repository;
using WpfDbApplication.Services.Helpers;

namespace WpfDbApplication.Facade
{
    public class AccountFacade
    {
        private IAccountRepository accountRepository;
        private ICardRepository cardRepository;
        private IUnitOfWork unitOfWork;

        public AccountFacade(IAccountRepository accountRepository, ICardRepository cardRepository, IUnitOfWork uow)
        {
            this.accountRepository = accountRepository;
            this.cardRepository = cardRepository;
            unitOfWork = uow;
        }

        public async Task Save(Account account)
        {
            int i = 0;
            try
            {
                // _unitOfWork.BeginTransaction();
                SQLiteTransaction sqlTransaction = unitOfWork.BeginTransaction();

                string strSqlCard = "Insert into Card (CardNum, Cvv, ExpDate) VALUES(@CardNum, @Cvv, @ExpDate)";
                i = await cardRepository.Insert(GeneralHelper.ToCardDto(account.card), strSqlCard, sqlTransaction);

                string strSqlAccount = "Insert into Account (Uuid, Nationality, Email, Money, CardId) VALUES (@Uuid, @Nationality, @Email, @Money, @CardId)";
                await accountRepository.Insert(GeneralHelper.ToAccountDto(account, i), strSqlAccount, sqlTransaction);
                
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task Update(string uuid, decimal money)
        {
            int i = 0;
            try
            {
                SQLiteTransaction sqlTransaction = unitOfWork.BeginTransaction();
                string strSql2 = "select * from Account where Uuid = @Uuid";
                AccountDto accountDto = await accountRepository.GetByUuid(uuid.Remove(0, 2), strSql2);
                accountDto.Money += money;
                string strSql = "Update Account set Uuid = @Uuid, Nationality = @Nationality, Email = @Email, Money = @Money, CardId = @CardId Where Id = @Id";
                await accountRepository.Update(accountDto, strSql, sqlTransaction);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(int id)
        {
            int i = 0;
            try
            {
                SQLiteTransaction sqlTransaction = unitOfWork.BeginTransaction();
                string strSql = "Delete from Account Where Id = @Id";
                i = accountRepository.Delete(id, strSql, sqlTransaction);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        public AccountDto GetById(int id)
        {
            string strSql = "select * from Account where Id = @id";
            //return accountRepository.GetById(id, strSql);
            return null;
        }

        public async Task<Account> GetByUuid(string uuid)
        {
            string strSql = "select * from Account where Uuid = @Uuid";
            AccountDto accountDto = await accountRepository.GetByUuid(uuid.Remove(0, 2), strSql);
            string strSql2 = "select * from Card where Id = @Id";
            CardDto cardDto = await cardRepository.GetById((int) accountDto.CardId, strSql2);
            return GeneralHelper.ToAccount(accountDto, cardDto);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            IEnumerable<AccountDto> AccountDtos = await accountRepository.GetAll("SELECT * FROM Account");
            if (AccountDtos != null && AccountDtos.Select(r => GeneralHelper.ToAccount(r)) != null)
            {
                return AccountDtos.Select(r => GeneralHelper.ToAccount(r));
            }
            return new List<Account>();
        }
    }
}
