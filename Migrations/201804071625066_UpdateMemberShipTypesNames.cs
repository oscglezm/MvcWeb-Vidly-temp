namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMemberShipTypesNames : DbMigration
    {
        public override void Up()
        {
            Sql("update  MemberShipTypes " +
                "set Name = 'Monthly'" +
                "where DurationInMonths = 1");

            Sql("update  MemberShipTypes " +
                "set Name = 'Quaterly'" +
                "where DurationInMonths = 3");

         }
        
        public override void Down()
        {
        }
    }
}
