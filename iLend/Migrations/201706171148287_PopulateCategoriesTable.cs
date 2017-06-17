namespace iLend.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCategoriesTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Categories (Id, Name) VALUES (1, 'Laptops')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (2, 'Tablets and Kindles')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (3, 'Desktop and Workstations')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (4, 'Printers and Supplies')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (5, 'Computer Components')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (6, 'Data Storage')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (7, 'Networking')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (8, 'Monitors')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (9, 'Accessoties')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (10, 'Software')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (11, 'Office Supplies and Furniture')");
            Sql("INSERT INTO Categories (Id, Name) VALUES (12, 'Gadgets and Novelties')");
        }
        
        public override void Down()
        {
        }
    }
}
