namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Position", c => c.String());
            DropColumn("dbo.Employees", "Postition");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Postition", c => c.String());
            DropColumn("dbo.Employees", "Position");
        }
    }
}
