using School_Stage_0.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace School_Stage_0.Repository
{
    public class AccountRepository : BaseRepository<AccountDto>, IAccountRepository
    {
        //base refers to UnitOfWork not its interface
        public AccountRepository(IUnitOfWork uow) : base(uow) {

        }

        /// <summary>
        /// Passes the parameters for Insert Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void InsertCommandParameters(AccountDto entity, SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Uuid", entity.Uuid);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Money", entity.Money);
            cmd.Parameters.AddWithValue("@Nationality", entity.Nationality);
        }
        /// <summary>
        /// Passes the parameters for Update Statement
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cmd"></param>
        protected override void UpdateCommandParameters(AccountDto entity, SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", entity.Id);
            cmd.Parameters.AddWithValue("@Uuid", entity.Uuid);
            cmd.Parameters.AddWithValue("@Email", entity.Email);
            cmd.Parameters.AddWithValue("@Money", entity.Money);
            cmd.Parameters.AddWithValue("@Nationality", entity.Nationality);
        }

        /// <summary>
        /// Passes the parameters to command for Delete Statement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void DeleteCommandParameters(int id, SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@Id", id);
        }

        /// <summary>
        /// Passes the parameters to command for populate by key statement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cmd"></param>
        protected override void GetByIdCommandParameters(int id, SQLiteCommand cmd)
        {
            cmd.Parameters.AddWithValue("@id", id);
        }

        /// <summary>
        /// Maps data for populate by key statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<AccountDto> Map(SQLiteDataReader reader)
        {
            AccountDto account = new AccountDto();
            if (reader.HasRows)
            {
                await Task.Run(() =>
                {
                    while (reader.Read())
                    {
                        account.Id = Convert.ToInt32(reader["Id"].ToString());
                        account.Uuid = reader["Uuid"].ToString();
                        account.Email = reader["Email"].ToString();
                        account.Money = Convert.ToInt32(reader["Money"].ToString());
                        account.Nationality = reader["Nationality"].ToString();
                    }
                });
            }
            return account;
        }

        /// <summary>
        /// Maps data for populate all statement
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected override async Task<List<AccountDto>> Maps(SQLiteDataReader reader)
        {
            List<AccountDto> accounts = new List<AccountDto>();
            if (reader.HasRows)
            {
                await Task.Run(() =>
                {
                    while (reader.Read())
                    {
                        AccountDto account = new AccountDto();
                        account.Id = Convert.ToInt32(reader["Id"].ToString());
                        account.Uuid = reader["Uuid"].ToString();
                        account.Email = reader["Email"].ToString();
                        account.Money = Convert.ToInt32(reader["Money"].ToString());
                        account.Nationality = reader["Nationality"].ToString();
                        accounts.Add(account);
                    }
                });
            }
            return accounts;
        }
    }
}
