namespace GamePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsDeletedToGame : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "IsDeleted");
        }
    }
}
