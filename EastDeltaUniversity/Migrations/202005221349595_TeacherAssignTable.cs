namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherAssignTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeacherAssigns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Teachers", t => t.TeacherId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
            AddColumn("dbo.Teachers", "CreditTaken", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherAssigns", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherAssigns", "CourseId", "dbo.Courses");
            DropIndex("dbo.TeacherAssigns", new[] { "CourseId" });
            DropIndex("dbo.TeacherAssigns", new[] { "TeacherId" });
            DropColumn("dbo.Teachers", "CreditTaken");
            DropTable("dbo.TeacherAssigns");
        }
    }
}
