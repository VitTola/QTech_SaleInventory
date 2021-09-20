namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v47 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sales", "ImportPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sales", "ImportPrice");
        }
    }
}
