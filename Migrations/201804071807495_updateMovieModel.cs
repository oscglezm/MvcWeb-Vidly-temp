namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMovieModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Movies", "GenreForeignId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreForeignId", c => c.Int(nullable: false));
        }
    }
}
