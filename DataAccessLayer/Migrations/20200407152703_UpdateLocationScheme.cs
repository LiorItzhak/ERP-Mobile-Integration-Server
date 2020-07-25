using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UpdateLocationScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessPartners",
                table: "BusinessPartners");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "Cid",
                table: "BusinessPartners");

            migrationBuilder.RenameColumn(
                name: "PictureURL",
                table: "ProductGroups",
                newName: "PictureUrl");

            migrationBuilder.AddColumn<string>(
                name: "MetaData",
                table: "UserLocations",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDateTime",
                table: "ProductGroups",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDateTime",
                table: "ProductGroups",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "BusinessPartners",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "AttachmentsCode",
                table: "BusinessPartners",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessPartners",
                table: "BusinessPartners",
                column: "Key");

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    AttachmentsCode = table.Column<int>(nullable: false),
                    Num = table.Column<int>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Ext = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => new { x.AttachmentsCode, x.Num });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusinessPartners",
                table: "BusinessPartners");

            migrationBuilder.DropColumn(
                name: "MetaData",
                table: "UserLocations");

            migrationBuilder.DropColumn(
                name: "CreationDateTime",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "LastUpdateDateTime",
                table: "ProductGroups");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "BusinessPartners");

            migrationBuilder.DropColumn(
                name: "AttachmentsCode",
                table: "BusinessPartners");

            migrationBuilder.RenameColumn(
                name: "PictureUrl",
                table: "ProductGroups",
                newName: "PictureURL");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProductGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "ProductGroups",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cid",
                table: "BusinessPartners",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusinessPartners",
                table: "BusinessPartners",
                column: "Cid");
        }
    }
}
