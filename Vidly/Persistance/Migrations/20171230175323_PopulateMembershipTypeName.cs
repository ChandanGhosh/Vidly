using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vidly.Persistance.Migrations
{
    public partial class PopulateMembershipTypeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Pay As You Go' WHERE DurationInMonths = 0");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE DurationInMonths = 1");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Quarterly' WHERE DurationInMonths = 3");
            migrationBuilder.Sql("UPDATE MembershipTypes SET Name = 'Yearly' WHERE DurationInMonths = 12");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
