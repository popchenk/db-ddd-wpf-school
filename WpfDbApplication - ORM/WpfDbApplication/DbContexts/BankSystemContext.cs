using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WpfDbApplication.DTOs;

#nullable disable

namespace WpfDbApplication.DbContexts
{
    public partial class BankSystemContext : DbContext
    {
        public DbSet<AccountDto> AccountDtos { get; set; }
        public DbSet<CardDto> CardDtos { get; set; }


        public BankSystemContext(DbContextOptions options) : base(options)
        {

        }
    }
}
