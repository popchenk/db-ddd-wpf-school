using School_Stage_0.DbContexts;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace School_Stage_0.Repository
{
    // Collects all transactions that repositories are using and make them into one single transaction
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private IDatabaseContextFactory factory;
        private IDatabaseContext context;
        public SQLiteTransaction Transaction { get; private set; }

        /// <summary>
        /// Constructor which will initialize the datacontext factory
        /// </summary>
        /// <param name="factory">datacontext factory</param>
        public UnitOfWork(IDatabaseContextFactory factory)
        {
            this.factory = factory;
        }

        /// <summary>
        /// Following method will use to Commit or Rollback memory data into database
        /// </summary>
        public void Commit()
        {
            if (Transaction != null)
            {
                try
                {
                    Transaction.Commit();
                }
                catch (Exception)
                {
                    Transaction.Rollback();
                }
                Transaction.Dispose();
                Transaction = null;
            }
            else
            {
                throw new NullReferenceException("Tryed commit not opened transaction");
            }
        }

        /// <summary>
        /// Define a property of context class
        /// </summary>
        public IDatabaseContext DataContext
        {
            get { return context ?? (context = factory.Context()); }
        }

        /// <summary>
        /// Begin a database transaction
        /// </summary>
        /// <returns>Transaction</returns>
        public SQLiteTransaction BeginTransaction()
        {
            if (Transaction != null)
            {
                throw new NullReferenceException("Not finished previous transaction");
            }
            Transaction = context.Connection.BeginTransaction();
            return Transaction;
        }

        /// <summary>
        /// dispose a Transaction.
        /// </summary>
        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
            }
            if (context != null)
            {
                context.Dispose();
            }
        }
    }
}
