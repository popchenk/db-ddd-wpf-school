using System;
using System.Collections.Generic;
using System.Text;

namespace School_Stage_0.DbContexts
{
    public class DatabaseContextFactory : IDatabaseContextFactory
    {
        private IDatabaseContext dataContext;

        /// <summary>
        /// If data context remain null then initialize new context 
        /// </summary>
        /// <returns>dataContext</returns>
        public IDatabaseContext Context()
        {
            return dataContext ?? (dataContext = new DatabaseContext());
        }

        /// <summary>
        /// Dispose existing context
        /// </summary>
        public void Dispose()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
