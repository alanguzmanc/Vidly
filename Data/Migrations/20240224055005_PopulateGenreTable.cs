using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulateGenreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Genres(Name) values('Comedy')");
            migrationBuilder.Sql("insert into Genres(Name) values('Action')");
            migrationBuilder.Sql("insert into Genres(Name) values('Horror')");
            migrationBuilder.Sql("insert into Genres(Name) values('SciFi')");
            migrationBuilder.Sql("insert into Genres(Name) values('Drama')");
            migrationBuilder.Sql("insert into Genres(Name) values('Romance')");
            migrationBuilder.Sql("insert into Genres(Name) values('Documental')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
