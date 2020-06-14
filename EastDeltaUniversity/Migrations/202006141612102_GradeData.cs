namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GradeData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('A',4.00)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('A-',3.7)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('B+',3.3)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('B',3.0)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('B-',2.7)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('C+',2.3)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('C',2.0)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('C-',1.7)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('D+',1.3)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('D',1.0)");
            Sql("INSERT INTO Grades (Letter,Point) VALUES ('F',0.0)");
        }
        
        public override void Down()
        {
        }
    }
}
