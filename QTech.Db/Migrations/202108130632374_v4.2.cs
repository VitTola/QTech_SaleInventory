namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v42 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SaleDetails", "IsBilled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sales", "IsInvoiced", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "IsInvoiced");
            DropColumn("dbo.SaleDetails", "IsBilled");
        }
    }
}
