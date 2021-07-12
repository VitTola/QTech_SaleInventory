namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleDetails", "Expense", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Sales", "Expense", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Expense");
            DropColumn("dbo.SaleDetails", "Expense");
        }
    }
}
