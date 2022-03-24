using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace School_Stage_0.DbContexts
{
    public interface IDatabaseContext
    {

        SQLiteConnection Connection { get; }
        void Dispose();

    }
}
