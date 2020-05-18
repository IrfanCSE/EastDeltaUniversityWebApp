namespace EastDeltaUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigDepartment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "Code", c => c.String(nullable: false, maxLength: 10, unicode: false));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String());
            AlterColumn("dbo.Departments", "Code", c => c.String());
        }
    }
}
