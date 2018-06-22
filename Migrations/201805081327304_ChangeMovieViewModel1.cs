namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeMovieViewModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
