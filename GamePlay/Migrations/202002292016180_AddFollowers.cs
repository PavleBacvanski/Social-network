namespace GamePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeID })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeID)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FolloweeID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "FolloweeID" });
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            DropTable("dbo.Follows");
        }
    }
}
