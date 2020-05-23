namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreditAddedToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Credit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Credit");
        }
    }
}
