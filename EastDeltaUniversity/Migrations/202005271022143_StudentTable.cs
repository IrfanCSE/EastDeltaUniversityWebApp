namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Registration = c.String(nullable: false, maxLength: 50, unicode: false),
                        Name = c.String(),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Contact = c.String(nullable: false, maxLength: 50, unicode: false),
                        Date = c.DateTime(nullable: false, storeType: "date"),
                        Address = c.String(nullable: false, maxLength: 250, unicode: false),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.Email, unique: true)
                .Index(t => t.Contact, unique: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            DropIndex("dbo.Students", new[] { "Contact" });
            DropIndex("dbo.Students", new[] { "Email" });
            DropTable("dbo.Students");
        }
    }
}
