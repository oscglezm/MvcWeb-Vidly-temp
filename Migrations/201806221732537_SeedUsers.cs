namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'341040e9-b022-4596-a1fd-c9d9ead5ed16', N'admin', N'AI1siR58OLGZFiIUqSckgFWd7wo3KeR7wIiLwjIAyhRse6h2/E4DQfZy5cAAcGXHpg==', N'641471fc-9677-4896-8be7-be6ba9336be9', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'efe10b25-35c0-4c13-8b5f-2322b976e976', N'guess', N'AF9MuROkekC5gDUv0Yvghezxz336yBDFK6h0t++Fj3KL5zlxTOTcA6ie04rkNbqdJg==', N'a961c56e-5208-4197-9532-5875ce85ecb9', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7dffa0cc-1d41-4dea-81b9-4d993daa738c', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'341040e9-b022-4596-a1fd-c9d9ead5ed16', N'7dffa0cc-1d41-4dea-81b9-4d993daa738c')



");
        }

        
        public override void Down()
        {
        }
    }
}
