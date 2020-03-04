namespace GamePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameCategory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ganres", newName: "Categories");
            RenameColumn(table: "dbo.Games", name: "Ganre_Id", newName: "Category_Id");
            RenameIndex(table: "dbo.Games", name: "IX_Ganre_Id", newName: "IX_Category_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Games", name: "IX_Category_Id", newName: "IX_Ganre_Id");
            RenameColumn(table: "dbo.Games", name: "Category_Id", newName: "Ganre_Id");
            RenameTable(name: "dbo.Categories", newName: "Ganres");
        }
    }
}
