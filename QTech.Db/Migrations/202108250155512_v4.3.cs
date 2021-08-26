namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v43 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeBills", "PrePaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.SupplierGeneralPaids", "EmployeeBillId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SupplierGeneralPaids", "EmployeeBillId");
            DropColumn("dbo.EmployeeBills", "PrePaidAmount");
        }
    }
}
