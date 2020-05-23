namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataOfDesignation : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Designations (Name) VALUES('Professor')");
            Sql("INSERT INTO Designations (Name) VALUES('Assistant Professor')");
            Sql("INSERT INTO Designations (Name) VALUES('Jr. Professor')");
            Sql("INSERT INTO Designations (Name) VALUES('Adjunct Professor')");
        }
        
        public override void Down()
        {
        }
    }
}
