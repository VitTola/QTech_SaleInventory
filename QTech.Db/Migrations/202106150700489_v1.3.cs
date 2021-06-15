namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Sites", "CustomerId");
            AddForeignKey("dbo.Sites", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "PositionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "PositionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Sites", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Sites", new[] { "CustomerId" });
        }
    }
}
