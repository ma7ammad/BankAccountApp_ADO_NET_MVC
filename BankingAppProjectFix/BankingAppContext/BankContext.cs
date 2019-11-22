using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;

namespace BankingAppContext
{
    public class BankContext : DbContext
    {
        //public BankContext()
        //    : base("name=BankContext")
        //{
        //}
        public BankContext(DbConnection connection)
            : base(connection, true)
        {
        }

        public BankContext() : base("BankContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }        
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<BankAccountType> BankAccountTypes { get; set; }

        //public virtual DbSet<SavingAccount> SavingAccounts { get; set; }
        //public virtual DbSet<CheckAccount> CheckAccounts { get; set; }
        

        //public virtual DbSet<AccountType> AccountTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<SavingAccount>().ToTable("SavingAccount");
            //modelBuilder.Entity<CheckAccount>().ToTable("CheckAccount");
            //modelBuilder.Entity<CheckAccount>().Property(c => c.CustomerId).HasColumnName("CustomerId");
            //modelBuilder.Entity<CheckAccount>().Property(c => c.Balance).HasColumnName("Balance");
            //modelBuilder.Entity<BankAccount>().Property(c => c.BankAccountTypeId).IsRequired();


            //modelBuilder.Properties<SavingAccount>()
            //modelBuilder.Entity<Customer>().Property(p => p.FirstName).IsRequired().HasMaxLength(20); //you can carry one chaining
            //modelBuilder.Entity<Customer>().Property(p => p.LastName).HasColumnName("Surname");
            //modelBuilder.Entity<BankAccountType>().Property(p => p.BankAccountTypeName = "Saving Account");

            //base.OnModelCreating(modelBuilder);
        }
    }
}
