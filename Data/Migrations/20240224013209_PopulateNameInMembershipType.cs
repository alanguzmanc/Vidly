using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulateNameInMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"UPDATE MembershipType SET Name='Default' where DurationInMonths=0"); 
            migrationBuilder.Sql(@"UPDATE MembershipType SET Name='Monthly' where DurationInMonths=1"); 
            migrationBuilder.Sql(@"UPDATE MembershipType SET Name='Trimesters' where DurationInMonths=3"); 
            migrationBuilder.Sql(@"UPDATE MembershipType SET Name='Anual' where DurationInMonths=12"); 

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
