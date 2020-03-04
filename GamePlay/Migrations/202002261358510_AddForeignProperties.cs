namespace GamePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignProperties : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Games", name: "Category_Id", newName: "CategoryID");
            RenameColumn(table: "dbo.Games", name: "Studio_Id", newName: "StudioId");
            RenameIndex(table: "dbo.Games", name: "IX_Studio_Id", newName: "IX_StudioId");
            RenameIndex(table: "dbo.Games", name: "IX_Category_Id", newName: "IX_CategoryID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Games", name: "IX_CategoryID", newName: "IX_Category_Id");
            RenameIndex(table: "dbo.Games", name: "IX_StudioId", newName: "IX_Studio_Id");
            RenameColumn(table: "dbo.Games", name: "StudioId", newName: "Studio_Id");
            RenameColumn(table: "dbo.Games", name: "CategoryID", newName: "Category_Id");
        }
    }
}
