namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClassTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        DayId = c.Int(nullable: false),
                        FromTime = c.Time(nullable: false, precision: 7),
                        ToTime = c.Time(nullable: false, precision: 7),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId)
                .ForeignKey("dbo.Days", t => t.DayId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Rooms", t => t.RoomId)
                .Index(t => t.DepartmentId)
                .Index(t => t.CourseId)
                .Index(t => t.RoomId)
                .Index(t => t.DayId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Classes", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Classes", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Classes", "DayId", "dbo.Days");
            DropForeignKey("dbo.Classes", "CourseId", "dbo.Courses");
            DropIndex("dbo.Classes", new[] { "DayId" });
            DropIndex("dbo.Classes", new[] { "RoomId" });
            DropIndex("dbo.Classes", new[] { "CourseId" });
            DropIndex("dbo.Classes", new[] { "DepartmentId" });
            DropTable("dbo.Classes");
        }
    }
}
