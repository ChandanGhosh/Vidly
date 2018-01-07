using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Vidly.Services;

namespace Vidly.Persistance.Migrations
{
    public partial class PopulateCustomersForDevelopment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (EnvironmentService.IsDevelopmentEnvironment())
            {
                migrationBuilder.Sql(
                    "INSERT INTO Customers(FirstName, LastName, IsSubscribedToNewsletter, MembershipTypeId) VALUES('Chandan', 'Ghosh', 0, 1)");
                migrationBuilder.Sql(
                    "INSERT INTO Customers(FirstName, LastName, IsSubscribedToNewsletter, MembershipTypeId) VALUES('Debjani', 'Ghosh', 1, 2)");
            }
            else
            {
                migrationBuilder.Sql(
                    "INSERT INTO Customers(FirstName, LastName, IsSubscribedToNewsletter, MembershipTypeId) VALUES('Arnab', 'Ghosh', 0, 1)");
                migrationBuilder.Sql(
                    "INSERT INTO Customers(FirstName, LastName, IsSubscribedToNewsletter, MembershipTypeId) VALUES('Chandrani', 'Ghosh', 1, 2)");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
