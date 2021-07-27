namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v41 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "SaleType", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "CustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "CustomerName");
            DropColumn("dbo.Invoices", "SaleType");
        }
    }
}
