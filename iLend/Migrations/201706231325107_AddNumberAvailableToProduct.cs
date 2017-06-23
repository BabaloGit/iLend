namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNumberAvailableToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "NumberAvailable", c => c.Byte(nullable: false));
            Sql("UPDATE Products SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "NumberAvailable");
        }
    }
}
