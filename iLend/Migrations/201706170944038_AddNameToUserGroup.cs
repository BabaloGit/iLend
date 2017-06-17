namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToUserGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserGroups", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserGroups", "Name");
        }
    }
}
