namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSemesterTable1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Semesters", new[] { "Code" });
            DropIndex("dbo.Semesters", new[] { "Name" });
            DropColumn("dbo.Semesters", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Semesters", "Code", c => c.String(nullable: false, maxLength: 10, unicode: false));
            CreateIndex("dbo.Semesters", "Name", unique: true);
            CreateIndex("dbo.Semesters", "Code", unique: true);
        }
    }
}
