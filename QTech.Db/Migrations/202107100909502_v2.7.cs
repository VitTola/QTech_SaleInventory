namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SupplierGeneralPaids", "IsCalculated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupplierGeneralPaids", "IsCalculated");
        }
    }
}
