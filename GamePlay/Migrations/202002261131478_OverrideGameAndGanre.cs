namespace GamePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideGameAndGanre : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "Ganre_Id", "dbo.Ganres");
            DropForeignKey("dbo.Games", "Studio_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Games", new[] { "Ganre_Id" });
            DropIndex("dbo.Games", new[] { "Studio_Id" });
            AlterColumn("dbo.Games", "Desc", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Games", "Ganre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Games", "Studio_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Ganres", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Games", "Ganre_Id");
            CreateIndex("dbo.Games", "Studio_Id");
            AddForeignKey("dbo.Games", "Ganre_Id", "dbo.Ganres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Games", "Studio_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Studio_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Games", "Ganre_Id", "dbo.Ganres");
            DropIndex("dbo.Games", new[] { "Studio_Id" });
            DropIndex("dbo.Games", new[] { "Ganre_Id" });
            AlterColumn("dbo.Ganres", "Name", c => c.String());
            AlterColumn("dbo.Games", "Studio_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Games", "Ganre_Id", c => c.Byte());
            AlterColumn("dbo.Games", "Desc", c => c.String());
            CreateIndex("dbo.Games", "Studio_Id");
            CreateIndex("dbo.Games", "Ganre_Id");
            AddForeignKey("dbo.Games", "Studio_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Games", "Ganre_Id", "dbo.Ganres", "Id");
        }
    }
}
