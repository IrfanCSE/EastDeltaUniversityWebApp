namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSemesterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 10, unicode: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Semesters", new[] { "Name" });
            DropIndex("dbo.Semesters", new[] { "Code" });
            DropTable("dbo.Semesters");
        }
    }
}
