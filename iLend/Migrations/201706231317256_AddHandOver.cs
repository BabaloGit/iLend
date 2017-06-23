namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHandOver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HandOvers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateHandedOver = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Product_Id = c.Int(nullable: false),
                        Recipient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recipients", t => t.Recipient_Id, cascadeDelete: true)
                .Index(t => t.Product_Id)
                .Index(t => t.Recipient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HandOvers", "Recipient_Id", "dbo.Recipients");
            DropForeignKey("dbo.HandOvers", "Product_Id", "dbo.Products");
            DropIndex("dbo.HandOvers", new[] { "Recipient_Id" });
            DropIndex("dbo.HandOvers", new[] { "Product_Id" });
            DropTable("dbo.HandOvers");
        }
    }
}
