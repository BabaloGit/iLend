namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserGroups : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO UserGroups (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (1, 0, 12, 0)");
            Sql("INSERT INTO UserGroups (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (2, 0, 12, 0)");
            Sql("INSERT INTO UserGroups (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (3, 0, 12, 0)");
            Sql("INSERT INTO UserGroups (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (4, 0, 12, 0)");
            Sql("INSERT INTO UserGroups (Id, SignUpFee, DurationInMonths, DiscountRate) VALUES (5, 0, 6, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
