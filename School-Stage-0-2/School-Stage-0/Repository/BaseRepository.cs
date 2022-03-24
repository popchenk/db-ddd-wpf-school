using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace School_Stage_0.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : Entity, new()
    {
        protected SQLiteConnection conn;
        protected readonly IUnitOfWork uow;

        /// <summary>
        /// Initialize the connection
        /// </summary>
        /// <param name="uow">UnitOfWork</param>
        public BaseRepository(IUnitOfWork uow)
        {
            if (uow == null) throw new ArgumentNullException("unitOfWork");
            this.uow = uow;
            conn = uow.DataContext.Connection;
        }

        /// <summary>
        /// Base Method for Insert Data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="insertSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public async Task<int> Insert(T entity, string insertSql, SQLiteTransaction sqlTransaction)
        {
            int i = 1;
            try
            {
                await Task.Run(() =>
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = insertSql;
                        cmd.CommandType = CommandType.Text;
                        cmd.Transaction = sqlTransaction;
                        InsertCommandParameters(entity, cmd);
                        cmd.ExecuteNonQuery();
                        i = (int)conn.LastInsertRowId;
                    }
                });

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return i;
        }

        /// <summary>
        /// Base Method for Update Data
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="updateSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public async Task Update(T entity, string updateSql, SQLiteTransaction sqlTransaction)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = updateSql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = sqlTransaction;
                UpdateCommandParameters(entity, cmd);
                await Task.Run(() =>
                {
                    cmd.ExecuteNonQuery();
                });
            }
        }

        /// <summary>
        /// Base Method for Delete Data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deleteSql"></param>
        /// <param name="sqlTransaction"></param>
        /// <returns></returns>
        public async Task Delete(int id, string deleteSql, SQLiteTransaction sqlTransaction)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = deleteSql;
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = sqlTransaction;
                DeleteCommandParameters(id, cmd);
                await Task.Run(() =>
                {
                    cmd.ExecuteNonQuery();
                });
            }

        }

        /// <summary>
        /// Base Method for Populate Data by key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getByIdSql"></param>
        /// <returns></returns>
        public async Task<T> GetById(int id, string getByIdSql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = getByIdSql;
                cmd.CommandType = CommandType.Text;
                GetByIdCommandParameters(id, cmd);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    return await Map(reader);
                }

            }
        }

        /// <summary>
        /// Base Method for Populate Data by key
        /// </summary>
        /// <param name="id"></param>
        /// <param name="getByIdSql"></param>
        /// <returns></returns>
        public async Task<T> GetByUuid(string uuid, string getByIdSql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = getByIdSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Uuid", uuid);
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    return await Map(reader);
                }

            }
        }

        /// <summary>
        /// Base Method for Populate All Data
        /// </summary>
        /// <param name="getAllSql"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> GetAll(string getAllSql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = getAllSql;
                cmd.CommandType = CommandType.Text;
                using (SQLiteDataReader reader = cmd.ExecuteReader())
                {
                    return await Maps(reader);
                }
            }
        }

        protected abstract void InsertCommandParameters(T entity, SQLiteCommand cmd);
        protected abstract void UpdateCommandParameters(T entity, SQLiteCommand cmd);
        protected abstract void DeleteCommandParameters(int id, SQLiteCommand cmd);
        protected abstract void GetByIdCommandParameters(int id, SQLiteCommand cmd);
        protected abstract Task<T> Map(SQLiteDataReader reader);
        protected abstract Task<List<T>> Maps(SQLiteDataReader reader);


    }
}
