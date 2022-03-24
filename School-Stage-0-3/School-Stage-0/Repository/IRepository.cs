using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace School_Stage_0.Repository
{
    public interface IRepository<T> where T : Entity
    {
        Task<int> Insert(T entity, string insertSql, SQLiteTransaction sqlTransaction);
        Task Update(T entity, string updateSql, SQLiteTransaction sqlTransaction);
        Task Delete(int id, string deleteSql, SQLiteTransaction sqlTransaction);
        Task<T> GetById(int id, string getByIdSql);
        Task<T> GetByUuid(string uuid, string getByIdSql);
        Task<IEnumerable<T>> GetAll(string getAllSql);
    }
}
