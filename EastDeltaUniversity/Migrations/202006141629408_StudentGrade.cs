namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentGrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StudentCourses", "GradeId", c => c.Int(nullable: true));
            CreateIndex("dbo.StudentCourses", "GradeId");
            AddForeignKey("dbo.StudentCourses", "GradeId", "dbo.Grades", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "GradeId", "dbo.Grades");
            DropIndex("dbo.StudentCourses", new[] { "GradeId" });
            DropColumn("dbo.StudentCourses", "GradeId");
        }
    }
}
