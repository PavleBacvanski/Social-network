namespace GamePlay.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'FPS')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'MOBA')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'RPG')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'RTS')");

        }

        public override void Down()
        {
            Sql("DELETE FROM Categories WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
