namespace BankingAppContext.Migrations
{
    using Pocos;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BankingAppContext.BankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BankingAppContext.BankContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.BankAccountTypes.AddOrUpdate(
              p => p.BankAccountTypeId,
              new BankAccountType { BankAccountTypeName = "Saving Account" },
              new BankAccountType { BankAccountTypeName = "Check Account" }
              //,new Person { FullName = "Rowan Miller" }
            );
            
        }
    }
}
