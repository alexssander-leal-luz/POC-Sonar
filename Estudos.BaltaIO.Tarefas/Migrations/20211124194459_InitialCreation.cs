using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Estudos.BaltaIO.Tarefas.Migrations
{
  public partial class InitialCreation : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
          .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
        name: "reg_publishers",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
          name = table.Column<string>(type: "varchar(100)", nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4"),
          Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
          CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
          UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
          DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_reg_publishers", x => x.Id);
        })
        .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
        name: "reg_books",
        columns: table => new
        {
          Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
          isbn = table.Column<string>(type: "varchar(100)", nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4"),
          title = table.Column<string>(type: "varchar(100)", nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4"),
          author = table.Column<string>(type: "varchar(100)", nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4"),
          language = table.Column<string>(type: "varchar(100)", nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4"),
          pages = table.Column<decimal>(type: "numeric(4,0)", nullable: false),
          publisher_id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
          Deleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
          CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
          UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
          DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_reg_books", x => x.Id);
          table.ForeignKey(
            name: "FK_reg_books_reg_publishers_publisher_id",
            column: x => x.publisher_id,
            principalTable: "reg_publishers",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
        })
        .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateIndex(
        name: "IX_reg_books_isbn",
        table: "reg_books",
        column: "isbn",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_reg_books_publisher_id",
        table: "reg_books",
        column: "publisher_id");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "reg_books");

      migrationBuilder.DropTable(
        name: "reg_publishers");
    }
  }
}
