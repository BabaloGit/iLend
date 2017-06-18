namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnnotationsToBirthdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipients", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipients", "BirthDate", c => c.DateTime());
        }
    }
}
