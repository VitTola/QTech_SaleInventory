namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeBills", "BillNo", c => c.String());
            AddColumn("dbo.SaleDetails", "PayStatus", c => c.Int(nullable: false));
            DropColumn("dbo.SaleDetails", "SupplierPayStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SaleDetails", "SupplierPayStatus", c => c.Int(nullable: false));
            DropColumn("dbo.SaleDetails", "PayStatus");
            DropColumn("dbo.EmployeeBills", "BillNo");
        }
    }
}
