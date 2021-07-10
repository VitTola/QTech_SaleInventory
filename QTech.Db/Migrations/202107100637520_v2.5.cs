namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v25 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SupplierGeneralPaids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SaleDetails", "SupplierPayStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaleDetails", "SupplierPayStatus");
            DropTable("dbo.SupplierGeneralPaids");
        }
    }
}
