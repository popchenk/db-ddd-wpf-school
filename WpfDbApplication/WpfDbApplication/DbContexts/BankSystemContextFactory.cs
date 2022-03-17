using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDbApplication.DbContexts
{
    public class BankSystemContextFactory
    {

        private readonly string connectionString;

        public BankSystemContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public BankSystemContext CreateDbContext()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<BankSystemContext>();
            DbContextOptions options = optionsBuilder.UseMySql(connectionString, Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.13-mariadb")).Options;
            return new BankSystemContext((DbContextOptions<BankSystemContext>)options);
            
        }

    }
}
