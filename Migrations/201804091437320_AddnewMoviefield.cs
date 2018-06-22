namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddnewMoviefield : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Movies", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Name", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Movies", name: "GenreId", newName: "Genre_Id");
        }
    }
}
