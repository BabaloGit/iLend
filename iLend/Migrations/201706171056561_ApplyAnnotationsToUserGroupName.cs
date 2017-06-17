namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToUserGroupName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserGroups", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserGroups", "Name", c => c.String());
        }
    }
}
