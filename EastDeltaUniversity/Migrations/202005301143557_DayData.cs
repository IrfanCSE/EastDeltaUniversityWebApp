namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DayData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Days (Name) VALUES ('Saturday')");
            Sql("INSERT INTO Days (Name) VALUES ('Sunday')");
            Sql("INSERT INTO Days (Name) VALUES ('Monday')");
            Sql("INSERT INTO Days (Name) VALUES ('Tuesday')");
            Sql("INSERT INTO Days (Name) VALUES ('Wednesday')");
            Sql("INSERT INTO Days (Name) VALUES ('Thursday')");
            Sql("INSERT INTO Days (Name) VALUES ('Friday')");
        }
        
        public override void Down()
        {
        }
    }
}
