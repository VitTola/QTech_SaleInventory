namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "SaleType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "SaleType");
        }
    }
}
