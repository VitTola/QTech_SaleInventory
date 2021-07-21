namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Permissions", "UiActivator", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Permissions", "UiActivator");
        }
    }
}
