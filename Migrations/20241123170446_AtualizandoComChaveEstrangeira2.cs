using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StreamingApi.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoComChaveEstrangeira2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPlaylist",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPlaylist",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
