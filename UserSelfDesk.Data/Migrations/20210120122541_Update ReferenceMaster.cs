using Microsoft.EntityFrameworkCore.Migrations;

namespace UserSelfDesk.Data.Migrations
{
    public partial class UpdateReferenceMaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReferenceMasters",
                table: "ReferenceMasters");

            migrationBuilder.RenameTable(
                name: "ReferenceMasters",
                newName: "ReferenceMaster");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ReferenceMaster",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RefCode",
                table: "ReferenceMaster",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ReferenceMaster",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReferenceMaster",
                table: "ReferenceMaster",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReferenceMaster",
                table: "ReferenceMaster");

            migrationBuilder.RenameTable(
                name: "ReferenceMaster",
                newName: "ReferenceMasters");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "ReferenceMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "RefCode",
                table: "ReferenceMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ReferenceMasters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReferenceMasters",
                table: "ReferenceMasters",
                column: "Id");
        }
    }
}
