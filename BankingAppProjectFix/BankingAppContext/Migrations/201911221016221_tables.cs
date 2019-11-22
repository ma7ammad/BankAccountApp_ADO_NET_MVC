namespace BankingAppContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BankAccountTypeId = c.Int(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Interestrate = c.Double(),
                    })
                .PrimaryKey(t => t.BankAccountId)
                .ForeignKey("dbo.BankAccountTypes", t => t.BankAccountTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.BankAccountTypeId);
            
            CreateTable(
                "dbo.BankAccountTypes",
                c => new
                    {
                        BankAccountTypeId = c.Int(nullable: false, identity: true),
                        BankAccountTypeName = c.String(),
                    })
                .PrimaryKey(t => t.BankAccountTypeId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        TaxIDNumber = c.Int(nullable: false),
                        Address = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.BankAccounts", "BankAccountTypeId", "dbo.BankAccountTypes");
            DropIndex("dbo.BankAccounts", new[] { "BankAccountTypeId" });
            DropIndex("dbo.BankAccounts", new[] { "CustomerId" });
            DropTable("dbo.Customers");
            DropTable("dbo.BankAccountTypes");
            DropTable("dbo.BankAccounts");
        }
    }
}
