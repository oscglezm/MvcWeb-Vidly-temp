namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondUpdateMemberShipTypeName : DbMigration
    {
        public override void Up()
        {
            Sql("update  MemberShipTypes " +
                "set Name = 'Pays as You Go'" +
                "where DurationInMonths = 0");

            Sql("update  MemberShipTypes " +
                "set Name = 'Yearly'" +
                "where DurationInMonths = 4");

        }
        
        public override void Down()
        {
        }
    }
}
