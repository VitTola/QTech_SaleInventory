namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v17 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SaleDetails", "SaleId", "dbo.Sales");
            DropIndex("dbo.SaleDetails", new[] { "SaleId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SaleDetails", "SaleId");
            AddForeignKey("dbo.SaleDetails", "SaleId", "dbo.Sales", "Id", cascadeDelete: true);
        }
    }
}
