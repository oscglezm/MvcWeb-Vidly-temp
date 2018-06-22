namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenreId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "GenreForeignId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Genre_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Movies", "Genre_Id");
            AddForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            DropColumn("dbo.Movies", "Genre_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "Genre_Name", c => c.String());
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "Name", c => c.String());
            DropColumn("dbo.Movies", "Genre_Id");
            DropColumn("dbo.Movies", "GenreForeignId");
            DropTable("dbo.Genres");
        }
    }
}
