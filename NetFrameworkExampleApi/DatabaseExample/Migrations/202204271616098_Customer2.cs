namespace DatabaseExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "BankAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "BankAccountId", c => c.Int(nullable: false));
        }
    }
}
