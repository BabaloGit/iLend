namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDomainModelWithCategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "CategoryId", c => c.Byte(nullable: false));
            AddColumn("dbo.Products", "DateAdded", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "NumberInStock", c => c.Byte(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "Name", c => c.String());
            DropColumn("dbo.Products", "NumberInStock");
            DropColumn("dbo.Products", "DateAdded");
            DropColumn("dbo.Products", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
