namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateToRecipient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipients", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipients", "BirthDate");
        }
    }
}
