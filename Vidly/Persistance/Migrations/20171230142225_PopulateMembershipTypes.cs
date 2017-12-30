using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Vidly.Persistance.Migrations
{
    public partial class PopulateMembershipTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(1, 0, 0, 0)"); // Id=1 PayAsyouGo

            migrationBuilder.Sql(
                "INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(2, 30, 1, 10)"); // Id=2 Monthly
            migrationBuilder.Sql(
                "INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(3, 90, 3, 15)"); // Id=3 Quarterly
            migrationBuilder.Sql(
                "INSERT INTO MembershipTypes(Id, SignUpFee, DurationInMonths, DiscountRate) VALUES(4, 300, 12, 20)"); // Id=2 Yearly

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
