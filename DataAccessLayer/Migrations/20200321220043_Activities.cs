using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Activities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankEntity");

            migrationBuilder.RenameColumn(
                name: "SN",
                table: "Salesmen",
                newName: "Sn");

            migrationBuilder.RenameColumn(
                name: "PictureURL",
                table: "Products",
                newName: "PictureUrl");

            migrationBuilder.AddColumn<int>(
                name: "DownPaymentRequestKey",
                table: "DocItemEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IndicatorCode",
                table: "BusinessPartners",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndustryCode",
                table: "BusinessPartners",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false),
                    BusinessPartnerCode = table.Column<string>(nullable: true),
                    HandleByEmployeeCode = table.Column<int>(nullable: true),
                    Action = table.Column<int>(nullable: false),
                    TypeCode = table.Column<int>(nullable: false),
                    SubjectCode = table.Column<int>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    BeginDateTime = table.Column<DateTime>(nullable: false),
                    DurationMinutes = table.Column<int>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: true),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: true),
                    CloseDate = table.Column<DateTime>(nullable: true),
                    IsClosed = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    BaseActivity = table.Column<int>(nullable: true),
                    Document = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ActivitySubjects",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivitySubjects", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CardIndicators",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardIndicators", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "CardIndustries",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardIndustries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DownPaymentRequests",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sn = table.Column<int>(nullable: true),
                    ExternalSn = table.Column<string>(nullable: true),
                    CustomerSn = table.Column<string>(nullable: true),
                    CustomerName = table.Column<string>(nullable: true),
                    CustomerFederalTaxId = table.Column<string>(nullable: true),
                    CustomerAddress = table.Column<string>(nullable: true),
                    IsClosed = table.Column<bool>(nullable: true),
                    IsCanceled = table.Column<bool>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    ClosingDate = table.Column<DateTime>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    SalesmanSn = table.Column<int>(nullable: true),
                    OwnerEmployeeSn = table.Column<int>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    VatPercent = table.Column<decimal>(type: "decimal(3,2)", nullable: true),
                    DocTotal = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    TotalDiscountAndRounding = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ToPay = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    GrossProfit = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    Vat = table.Column<decimal>(type: "decimal(10,3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownPaymentRequests", x => x.Key);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocItemEntity_DownPaymentRequestKey",
                table: "DocItemEntity",
                column: "DownPaymentRequestKey");

            migrationBuilder.AddForeignKey(
                name: "FK_DocItemEntity_DownPaymentRequests_DownPaymentRequestKey",
                table: "DocItemEntity",
                column: "DownPaymentRequestKey",
                principalTable: "DownPaymentRequests",
                principalColumn: "Key",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocItemEntity_DownPaymentRequests_DownPaymentRequestKey",
                table: "DocItemEntity");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "ActivitySubjects");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "CardIndicators");

            migrationBuilder.DropTable(
                name: "CardIndustries");

            migrationBuilder.DropTable(
                name: "DownPaymentRequests");

            migrationBuilder.DropIndex(
                name: "IX_DocItemEntity_DownPaymentRequestKey",
                table: "DocItemEntity");

            migrationBuilder.DropColumn(
                name: "DownPaymentRequestKey",
                table: "DocItemEntity");

            migrationBuilder.DropColumn(
                name: "IndicatorCode",
                table: "BusinessPartners");

            migrationBuilder.DropColumn(
                name: "IndustryCode",
                table: "BusinessPartners");

            migrationBuilder.RenameColumn(
                name: "Sn",
                table: "Salesmen",
                newName: "SN");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "Products",
                newName: "PictureURL");

            migrationBuilder.CreateTable(
                name: "BankEntity",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    CountryCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankEntity", x => x.Code);
                });
        }
    }
}
