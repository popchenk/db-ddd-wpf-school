using School_Stage_0.DTOs;
using School_Stage_0.Helpers;
using School_Stage_0.Models;
using School_Stage_0.Repository;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Stage_0.Facade
{
    public class AccountFacade
    {
        private IAccountRepository accountRepository;
        private IUnitOfWork unitOfWork;

        public AccountFacade(IAccountRepository accountRepository, IUnitOfWork uow)
        {
            this.accountRepository = accountRepository;
            unitOfWork = uow;
        }

        public async Task Save(Account account)
        {
            try
            {
                // unitOfWork.BeginTransaction();
                SQLiteTransaction sqlTransaction = unitOfWork.BeginTransaction();

                string strSqlAccount = "Insert into Account (Uuid, Nationality, Email, Money) VALUES (@Uuid, @Nationality, @Email, @Money)";
                await accountRepository.Insert(GeneralHelper.ToAccountDto(account), strSqlAccount, sqlTransaction);

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task Update(string uuid, decimal money)
        {

            try
            {
                SQLiteTransaction sqlTransaction = unitOfWork.BeginTransaction();
                string strSql2 = "select * from Account where Uuid = @Uuid";
                AccountDto accountDto = await accountRepository.GetByUuid(uuid.Remove(0, 2), strSql2);
                accountDto.Money += money;
                string strSql = "Update Account set Uuid = @Uuid, Nationality = @Nationality, Email = @Email, Money = @Money Where Id = @Id";
                await accountRepository.Update(accountDto, strSql, sqlTransaction);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                SQLiteTransaction sqlTransaction = unitOfWork.BeginTransaction();
                string strSql = "Delete from Account Where Id = @Id";
                await accountRepository.Delete(id, strSql, sqlTransaction);
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            return GeneralHelper.ToAccount(accountDto);
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
