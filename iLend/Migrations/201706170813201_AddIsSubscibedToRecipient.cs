namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscibedToRecipient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipients", "IsSubscibedToNewsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipients", "IsSubscibedToNewsletter");
        }
    }
}
