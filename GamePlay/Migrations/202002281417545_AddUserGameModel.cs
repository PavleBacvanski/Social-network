namespace GamePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserGameModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        GameId = c.Int(nullable: false),
                        AppUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.GameId, t.AppUserId })
                .ForeignKey("dbo.AspNetUsers", t => t.AppUserId, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.GameId)
                .Index(t => t.GameId)
                .Index(t => t.AppUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGames", "GameId", "dbo.Games");
            DropForeignKey("dbo.UserGames", "AppUserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserGames", new[] { "AppUserId" });
            DropIndex("dbo.UserGames", new[] { "GameId" });
            DropTable("dbo.UserGames");
        }
    }
}
