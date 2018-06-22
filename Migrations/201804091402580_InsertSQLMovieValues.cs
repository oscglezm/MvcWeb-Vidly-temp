namespace MovieWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertSQLMovieValues : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock,Genre_Id)" +
                "VALUES ('The Greatest Showman','12/07/2017',75,7);");


            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock,Genre_Id)" +
                "VALUES ('Interstellar','11/07/2014',50,5);");


            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock,Genre_Id)" +
                "VALUES ('Les Misérables','12/25/2012',150,7);");


            Sql("INSERT INTO Movies (Name, ReleaseDate, NumberInStock,Genre_Id)" +
                "VALUES ('Silver Linings Playbook','12/25/2012',275,6);");

        }
        
        public override void Down()
        {
        }
    }
}
