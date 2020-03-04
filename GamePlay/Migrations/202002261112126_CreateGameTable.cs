namespace GamePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGameTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        MyProperty = c.String(),
                        Ganre_Id = c.Byte(),
                        Studio_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ganres", t => t.Ganre_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Studio_Id)
                .Index(t => t.Ganre_Id)
                .Index(t => t.Studio_Id);
            
            CreateTable(
                "dbo.Ganres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Studio_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Games", "Ganre_Id", "dbo.Ganres");
            DropIndex("dbo.Games", new[] { "Studio_Id" });
            DropIndex("dbo.Games", new[] { "Ganre_Id" });
            DropTable("dbo.Ganres");
            DropTable("dbo.Games");
        }
    }
}
