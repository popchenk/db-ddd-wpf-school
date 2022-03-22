using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.DbContexts
{
    public interface IDatabaseContext
    {
        SQLiteConnection Connection { get; }
        void Dispose();
    }
}
