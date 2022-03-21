using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.DbContexts
{
    public class BankSystemContextFactory : IDesignTimeDbContextFactory<BankSystemContext>
    {

        private readonly string connectionString;

        public BankSystemContextFactory()
        {

        }

        public BankSystemContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public BankSystemContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=bank.db").Options;
            return new BankSystemContext(options);
            
        }

        public BankSystemContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=bank.db").Options;
            return new BankSystemContext(options);
        }
    }
}
