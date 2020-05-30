namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTable1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Name", c => c.String());
        }
    }
}
