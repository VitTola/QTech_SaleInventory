namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "CustomerName", c => c.String());
            AddColumn("dbo.Sales", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "Phone");
            DropColumn("dbo.Sales", "CustomerName");
        }
    }
}
