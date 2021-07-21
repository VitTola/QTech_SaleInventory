namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "AuthKey", c => c.Int(nullable: false));
            AddColumn("dbo.Permissions", "Active", c => c.Boolean(nullable: false));
            DropColumn("dbo.Permissions", "ModuleId");
            DropColumn("dbo.Permissions", "UiActivator");
            DropColumn("dbo.Permissions", "ApiEndPoint");
            DropColumn("dbo.Permissions", "Note1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Permissions", "Note1", c => c.String());
            AddColumn("dbo.Permissions", "ApiEndPoint", c => c.String());
            AddColumn("dbo.Permissions", "UiActivator", c => c.String());
            AddColumn("dbo.Permissions", "ModuleId", c => c.Int(nullable: false));
            DropColumn("dbo.Permissions", "Active");
            DropColumn("dbo.Permissions", "AuthKey");
        }
    }
}
