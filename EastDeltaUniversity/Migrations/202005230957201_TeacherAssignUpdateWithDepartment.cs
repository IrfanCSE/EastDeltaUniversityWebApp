namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherAssignUpdateWithDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TeacherAssigns", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.TeacherAssigns", "DepartmentId");
            AddForeignKey("dbo.TeacherAssigns", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherAssigns", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.TeacherAssigns", new[] { "DepartmentId" });
            DropColumn("dbo.TeacherAssigns", "DepartmentId");
        }
    }
}
