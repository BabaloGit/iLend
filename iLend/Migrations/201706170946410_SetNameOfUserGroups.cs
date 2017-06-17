namespace iLend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfUserGroups : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE UserGroups SET Name = 'Developers' WHERE Id = 1");
            Sql("UPDATE UserGroups SET Name = 'Office Admin' WHERE Id = 2");
            Sql("UPDATE UserGroups SET Name = 'Trainers' WHERE Id = 3");
            Sql("UPDATE UserGroups SET Name = 'General Staff' WHERE Id = 4");
            Sql("UPDATE UserGroups SET Name = 'Interns' WHERE Id = 5");
        }
        
        public override void Down()
        {
        }
    }
}
