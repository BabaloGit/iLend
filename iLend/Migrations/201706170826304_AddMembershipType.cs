namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Recipients", "UserGroupId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Recipients", "UserGroupId");
            AddForeignKey("dbo.Recipients", "UserGroupId", "dbo.UserGroups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipients", "UserGroupId", "dbo.UserGroups");
            DropIndex("dbo.Recipients", new[] { "UserGroupId" });
            DropColumn("dbo.Recipients", "UserGroupId");
            DropTable("dbo.UserGroups");
        }
    }
}
