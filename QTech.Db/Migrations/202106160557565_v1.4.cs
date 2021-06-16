namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sites", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Sites", new[] { "CustomerId" });
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String());
            CreateIndex("dbo.Sites", "CustomerId");
            AddForeignKey("dbo.Sites", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
