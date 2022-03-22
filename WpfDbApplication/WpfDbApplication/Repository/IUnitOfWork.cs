using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDbApplication.DbContexts;

namespace WpfDbApplication.Repository
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Gets the context.
        /// </summary>
        IDatabaseContext DataContext { get; }
        SQLiteTransaction BeginTransaction();

        /// <summary>
        /// The Commit.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        void Commit();

    }
}
