namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v48 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.POProductPrices", "StartQauntity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.POProductPrices", "LeftQauntity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.SaleDetails", "Qauntity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SaleDetails", "Qauntity", c => c.Int(nullable: false));
            AlterColumn("dbo.POProductPrices", "LeftQauntity", c => c.Int(nullable: false));
            AlterColumn("dbo.POProductPrices", "StartQauntity", c => c.Int(nullable: false));
        }
    }
}
