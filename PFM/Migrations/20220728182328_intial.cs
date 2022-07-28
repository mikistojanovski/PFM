using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PFM.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    parentcode = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    parentcode = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    beneficiaryname = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    direction = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    currency = table.Column<string>(type: "text", nullable: true),
                    mcc = table.Column<int>(type: "integer", nullable: true),
                    kind = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    beneficiaryname = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    direction = table.Column<string>(type: "text", nullable: true),
                    amount = table.Column<double>(type: "double precision", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    currency = table.Column<string>(type: "text", nullable: true),
                    mcc = table.Column<int>(type: "integer", nullable: true),
                    kind = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ParentCode = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SubCategory_Category_ParentCode",
                        column: x => x.ParentCode,
                        principalTable: "Category",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_SubCategory_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Splits",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transactionid = table.Column<int>(type: "integer", nullable: false),
                    categorycode = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Splits", x => x.id);
                    table.ForeignKey(
                        name: "FK_Splits_Categories_categorycode",
                        column: x => x.categorycode,
                        principalTable: "Categories",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_Splits_Transactions_transactionid",
                        column: x => x.transactionid,
                        principalTable: "Transactions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    code = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    parentcode = table.Column<string>(type: "text", nullable: true),
                    TransactionId = table.Column<int>(type: "integer", nullable: true),
                    CategoryEntitycode = table.Column<string>(type: "text", nullable: true),
                    TransactionEntityid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.code);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryEntitycode",
                        column: x => x.CategoryEntitycode,
                        principalTable: "Categories",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_SubCategories_Category_parentcode",
                        column: x => x.parentcode,
                        principalTable: "Category",
                        principalColumn: "code");
                    table.ForeignKey(
                        name: "FK_SubCategories_Transaction_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transaction",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_SubCategories_Transactions_TransactionEntityid",
                        column: x => x.TransactionEntityid,
                        principalTable: "Transactions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Splits_categorycode",
                table: "Splits",
                column: "categorycode");

            migrationBuilder.CreateIndex(
                name: "IX_Splits_transactionid",
                table: "Splits",
                column: "transactionid");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryEntitycode",
                table: "SubCategories",
                column: "CategoryEntitycode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_parentcode",
                table: "SubCategories",
                column: "parentcode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_TransactionEntityid",
                table: "SubCategories",
                column: "TransactionEntityid");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_TransactionId",
                table: "SubCategories",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_ParentCode",
                table: "SubCategory",
                column: "ParentCode");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_TransactionId",
                table: "SubCategory",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Splits");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Transaction");
        }
    }
}
