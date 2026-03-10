using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class Add_Column_Student_Age : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");
        }
    }
}
