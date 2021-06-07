namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v10 : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FullName = c.String(),
                        PasswordHash = c.String(),
                        IsPasswordExpire = c.Boolean(nullable: false),
                        PasswordExpireDate = c.DateTime(nullable: false),
                        IsLocked = c.Boolean(nullable: false),
                        IsNeedChangePassword = c.Boolean(nullable: false),
                        CurrentSessionId = c.Guid(nullable: false),
                        LastLoginTime = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                        LastModifyDate = c.DateTime(nullable: false),
                        LastModifyBy = c.String(),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Permissions");
        }
    }
}
