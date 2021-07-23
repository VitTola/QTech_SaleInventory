namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v40 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IncomeExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MiscNo = c.String(),
                        DoDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MiscellaneousType = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        RowDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.IncomeExpenses");
        }
    }
}
