namespace GamePlay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGameTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "Desc", c => c.String());
            DropColumn("dbo.Games", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "MyProperty", c => c.String());
            DropColumn("dbo.Games", "Desc");
        }
    }
}
