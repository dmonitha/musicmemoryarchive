using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MMADatabase.Migrations
{
    /// <inheritdoc />
    public partial class Ratings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NumberofSongs = table.Column<int>(name: "Number of Songs", type: "int", nullable: false),
                    Artist = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    YearofRelease = table.Column<int>(name: "Year of Release", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongName = table.Column<string>(name: "Song Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AlbumID = table.Column<int>(name: "Album ID", type: "int", nullable: false),
                    FeaturingArtist = table.Column<string>(name: "Featuring Artist", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Song_Album",
                        column: x => x.AlbumID,
                        principalTable: "Album",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Song_Album ID",
                table: "Song",
                column: "Album ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Song");

            migrationBuilder.DropTable(
                name: "Album");
        }
    }
}
