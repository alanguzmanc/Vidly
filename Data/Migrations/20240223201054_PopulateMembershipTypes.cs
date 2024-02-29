using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO MembershipType (SingUpFee, DurationInMonths, DiscountRate) VALUES(0,0,0)");
            migrationBuilder.Sql("INSERT INTO MembershipType (SingUpFee, DurationInMonths, DiscountRate) VALUES(30,1,10)");
            migrationBuilder.Sql("INSERT INTO MembershipType (SingUpFee, DurationInMonths, DiscountRate) VALUES(90,3,15)");
            migrationBuilder.Sql("INSERT INTO MembershipType (SingUpFee, DurationInMonths, DiscountRate) VALUES(300,12,20)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
