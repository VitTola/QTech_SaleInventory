namespace QTech.Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v53 : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                    UPDATE Permissions SET Ordering = 3 WHERE Id = 60
                    UPDATE Permissions SET Ordering = 4 WHERE Id = 61
                    UPDATE Permissions SET Ordering = 5 WHERE Id = 62
                    UPDATE Permissions SET Ordering = 6 WHERE Id = 63

                    INSERT INTO Permissions (Name,Level,ParentId,PermissionType,UiActivator,Ordering,Note,RowDate,CreatedBy,Active,AuthKey) VALUES(N'របាយការណ៍ស្ថានភាពវិក័យប័ត្រ','2','6','3','Report_InvoiceStatus','2','InitData',GetDate(),'Init','1','64')
                    
                    INSERT INTO UserPermissions VALUES(0,64,1,GETDATE(),'INIT DATA')
              ");
        }
        
        public override void Down()
        {
        }
    }
}
