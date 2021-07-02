namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "PayStatus", c => c.Int(nullable: false));
            DropColumn("dbo.Sales", "IsPaid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sales", "IsPaid", c => c.Boolean(nullable: false));
            DropColumn("dbo.Sales", "PayStatus");
        }
    }
}
