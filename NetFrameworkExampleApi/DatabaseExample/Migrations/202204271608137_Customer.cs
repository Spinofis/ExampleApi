namespace DatabaseExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BankAccountId = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BankAccounts", "Customer_Id", c => c.Int());
            CreateIndex("dbo.BankAccounts", "Customer_Id");
            AddForeignKey("dbo.BankAccounts", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BankAccounts", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.BankAccounts", new[] { "Customer_Id" });
            DropColumn("dbo.BankAccounts", "Customer_Id");
            DropTable("dbo.Customers");
        }
    }
}
