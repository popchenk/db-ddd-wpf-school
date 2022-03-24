using School_Stage_0.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace School_Stage_0.Repository
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
