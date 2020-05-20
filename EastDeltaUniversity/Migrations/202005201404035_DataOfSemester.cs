namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataOfSemester : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Semesters (Name) VALUES ('Semester-1');");
            Sql("INSERT INTO Semesters (Name) VALUES ('Semester-2');");
            Sql("INSERT INTO Semesters (Name) VALUES ('Semester-3');");
            Sql("INSERT INTO Semesters (Name) VALUES ('Semester-4');");
            Sql("INSERT INTO Semesters (Name) VALUES ('Semester-5');");
            Sql("INSERT INTO Semesters (Name) VALUES ('Semester-6');");
            Sql("INSERT INTO Semesters (Name) VALUES ('Semester-7');");
            Sql("INSERT INTO Semesters (Name) VALUES ('Semester-8');");
        }
        
        public override void Down()
        {
        }
    }
}
