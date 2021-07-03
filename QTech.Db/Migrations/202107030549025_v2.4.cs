namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoices", "InvoiceStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoices", "InvoiceStatus");
        }
    }
}
