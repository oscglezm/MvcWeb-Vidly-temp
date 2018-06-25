namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDrivingLicense : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DriverLicense");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "DriverLicense", c => c.String(maxLength: 255));
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
    }
}
