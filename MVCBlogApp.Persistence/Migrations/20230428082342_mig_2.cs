using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCBlogApp.Persistence.Migrations
{
    public partial class mig_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_TaylanK",
                table: "TaylanK",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TaylanK",
                table: "TaylanK");
        }
    }
}
