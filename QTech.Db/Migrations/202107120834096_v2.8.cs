namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v28 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeBills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoDate = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CustomerId = c.Int(nullable: false),
                        SiteId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Permissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                        ParentId = c.Int(nullable: false),
                        ModuleId = c.Int(nullable: false),
                        PermissionType = c.Int(nullable: false),
                        UiActivator = c.String(),
                        ApiEndPoint = c.String(),
                        Ordering = c.Int(nullable: false),
                        Note = c.String(),
                        Note1 = c.String(),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.POProductPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseOrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        StartQauntity = c.Int(nullable: false),
                        LeftQauntity = c.Int(nullable: false),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Note = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PurchaseOrders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CustomerId = c.Int(nullable: false),
                        Note = c.String(),
                        IsReachQty = c.Boolean(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPermissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PermissionId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FullName = c.String(),
                        PasswordHash = c.String(),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.SaleDetails", "EmployeeBillId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SaleDetails", "EmployeeBillId");
            DropTable("dbo.Users");
            DropTable("dbo.UserPermissions");
            DropTable("dbo.PurchaseOrders");
            DropTable("dbo.POProductPrices");
            DropTable("dbo.Permissions");
            DropTable("dbo.EmployeeBills");
        }
    }
}
