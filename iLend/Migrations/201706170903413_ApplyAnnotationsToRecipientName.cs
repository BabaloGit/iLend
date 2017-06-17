namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToRecipientName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipients", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipients", "Name", c => c.String());
        }
    }
}
