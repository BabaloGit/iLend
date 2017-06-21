namespace iLend.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8b5364ed-0e22-4c5d-8b88-063edaf525a8', N'guest@siyaleader.net', 0, N'AH5XqMGzaL3Ri+dVt5xPIU4n692ESh0oM8fpOqER6uR05f5dXw0k4q1lsffnE0+y3Q==', N'19dbe381-7eb8-4cc2-a514-34dadcacd130', NULL, 0, 0, NULL, 1, 0, N'guest@siyaleader.net')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bcf8070b-5d17-49a4-9897-895589836361', N'admin@siyaleader.net', 0, N'AEY3nE7YYb8zwLpqjBsY0NLL+zx6ePZgp8mB+BlrzdPYbdOqVXkpluoHnq7ldSBYzA==', N'40d2dab8-17fd-40b5-9c3b-3f6697306642', NULL, 0, 0, NULL, 1, 0, N'admin@siyaleader.net')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3ae14bfc-95be-4fd0-baea-e581a3963b2c', N'CanManageProducts')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'bcf8070b-5d17-49a4-9897-895589836361', N'3ae14bfc-95be-4fd0-baea-e581a3963b2c')
");
        }
        
        public override void Down()
        {
        }
    }
}
