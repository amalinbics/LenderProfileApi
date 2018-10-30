namespace LenderProfileApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedCibilScoresTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CibilScores(Id,Score) VALUES(1,'900-750');");
            Sql("INSERT INTO CibilScores(Id,Score) VALUES(2,'749-500');");
            Sql("INSERT INTO CibilScores(Id,Score) VALUES(3,'499-400');");
            Sql("INSERT INTO CibilScores(Id,Score) VALUES(4,'399-300');");
        }
        
        public override void Down()
        {
        }
    }
}
