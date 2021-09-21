namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v50 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditTrails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ClientAddress = c.String(nullable: false, maxLength: 200),
                        ClientName = c.String(),
                        OperatorName = c.String(),
                        OperatorGroup = c.String(nullable: false, maxLength: 200),
                        TableName = c.String(),
                        TablePK = c.String(nullable: false, maxLength: 100),
                        ChangeJson = c.String(nullable: false, storeType: "ntext"),
                        TableValue = c.String(nullable: false, maxLength: 1000),
                        TableShortName = c.String(),
                        TransactionDate = c.DateTime(nullable: false),
                        UserName = c.String(),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuditTrails");
        }
    }
}
