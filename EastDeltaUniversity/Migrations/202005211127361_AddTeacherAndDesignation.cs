namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacherAndDesignation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Address = c.String(nullable: false, maxLength: 250, unicode: false),
                        Email = c.String(nullable: false, maxLength: 100, unicode: false),
                        ContactNo = c.String(nullable: false, maxLength: 20, unicode: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Designations", t => t.DesignationId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.ContactNo, unique: true)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropIndex("dbo.Teachers", new[] { "ContactNo" });
            DropIndex("dbo.Teachers", new[] { "Email" });
            DropTable("dbo.Designations");
            DropTable("dbo.Teachers");
        }
    }
}
