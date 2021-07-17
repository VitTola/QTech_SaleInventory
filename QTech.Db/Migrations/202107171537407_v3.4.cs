namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeBills", "PaidAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EmployeeBills", "LeftAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.EmployeeBills", "InvoiceStatus", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeBills", "InvoiceStatus");
            DropColumn("dbo.EmployeeBills", "LeftAmount");
            DropColumn("dbo.EmployeeBills", "PaidAmount");
        }
    }
}
