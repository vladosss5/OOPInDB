using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseInheritance.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    f_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    s_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    l_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PersonType = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    count_visits = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                    login = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
