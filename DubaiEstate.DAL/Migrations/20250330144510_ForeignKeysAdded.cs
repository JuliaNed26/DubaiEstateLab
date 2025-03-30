using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DubaiEstate.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    area_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    area_name_en = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area1", x => x.area_id);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    day = table.Column<int>(type: "int", nullable: false),
                    month = table.Column<int>(type: "int", nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    month_year = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date12", x => x.date);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    property_type_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    property_type_en = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType1", x => x.property_type_id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionsGroup",
                columns: table => new
                {
                    trans_group_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trans_group_en = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionsGroup1", x => x.trans_group_id);
                });

            migrationBuilder.CreateTable(
                name: "PropertySubType",
                columns: table => new
                {
                    property_sub_type_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    property_sub_type_en = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    property_type_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySubType1", x => x.property_sub_type_id);
                    table.ForeignKey(
                        name: "FK_PropertySubType1_PropertyType1",
                        column: x => x.property_type_id,
                        principalTable: "PropertyType",
                        principalColumn: "property_type_id");
                });

            migrationBuilder.CreateTable(
                name: "Procedure",
                columns: table => new
                {
                    procedure_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    procedure_name_en = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    trans_group_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procedure1", x => x.procedure_id);
                    table.ForeignKey(
                        name: "FK_Procedure1_TransactionsGroup1",
                        column: x => x.trans_group_id,
                        principalTable: "TransactionsGroup",
                        principalColumn: "trans_group_id");
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    procedure_area = table.Column<double>(type: "float", nullable: false),
                    actual_worth = table.Column<int>(type: "int", nullable: true),
                    rent_value = table.Column<int>(type: "int", nullable: true),
                    procedure_id = table.Column<long>(type: "bigint", nullable: false),
                    instance_date = table.Column<DateOnly>(type: "date", nullable: false),
                    property_sub_type_id = table.Column<long>(type: "bigint", nullable: false),
                    area_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Transactions_Area_area_id",
                        column: x => x.area_id,
                        principalTable: "Area",
                        principalColumn: "area_id");
                    table.ForeignKey(
                        name: "FK_Transactions_Date",
                        column: x => x.instance_date,
                        principalTable: "Date",
                        principalColumn: "date");
                    table.ForeignKey(
                        name: "FK_Transactions_Procedure_procedure_id",
                        column: x => x.procedure_id,
                        principalTable: "Procedure",
                        principalColumn: "procedure_id");
                    table.ForeignKey(
                        name: "FK_Transactions_PropertySubType_property_sub_type_id",
                        column: x => x.property_sub_type_id,
                        principalTable: "PropertySubType",
                        principalColumn: "property_sub_type_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Procedure_trans_group_id",
                table: "Procedure",
                column: "trans_group_id");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySubType_property_type_id",
                table: "PropertySubType",
                column: "property_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_area_id",
                table: "Transactions",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_instance_date",
                table: "Transactions",
                column: "instance_date");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_procedure_id",
                table: "Transactions",
                column: "procedure_id");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_property_sub_type_id",
                table: "Transactions",
                column: "property_sub_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "Procedure");

            migrationBuilder.DropTable(
                name: "PropertySubType");

            migrationBuilder.DropTable(
                name: "TransactionsGroup");

            migrationBuilder.DropTable(
                name: "PropertyType");
        }
    }
}
