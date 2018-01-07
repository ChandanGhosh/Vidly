using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vidly.Persistance.Migrations
{
    public partial class PopulateGenreData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(1, 'Action')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(2, 'Thriller')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(3, 'Comedy')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(4, 'Family')");
            migrationBuilder.Sql("INSERT INTO Genres(Id, Name) VALUES(5, 'Romance')");
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
