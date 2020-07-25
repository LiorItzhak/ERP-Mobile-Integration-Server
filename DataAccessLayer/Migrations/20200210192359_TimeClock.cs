using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class TimeClock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountBalanceRecords",
                columns: table => new
                {
                    SN = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OwnerSn = table.Column<string>(nullable: true),
                    Doc1Sn = table.Column<string>(nullable: true),
                    Doc2Sn = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Debt = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    BalanceDebt = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    Memo = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalanceRecords", x => x.SN);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Block = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    NumAtStreet = table.Column<string>(nullable: true),
                    Apartment = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.ID);
                });

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

            migrationBuilder.CreateTable(
                name: "BusinessPartners",
                columns: table => new
                {
                    Cid = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GroupSn = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: true),
                    PartnerType = table.Column<int>(nullable: true),
                    FederalTaxId = table.Column<string>(nullable: true),
                    Phone1 = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Cellular = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    BillingAddress = table.Column<string>(nullable: true),
                    ShippingAddress = table.Column<string>(nullable: true),
                    GeoLocation = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    OrdersBalance = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    DeliveryNotesBalance = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    DiscountPercent = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    IsVatFree = table.Column<bool>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: true),
                    SalesmanCode = table.Column<int>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    IsFavorite = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartners", x => x.Cid);
                });

            migrationBuilder.CreateTable(
                name: "CardGroups",
                columns: table => new
                {
                    Sn = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardGroups", x => x.Sn);
                });

            migrationBuilder.CreateTable(
                name: "CreditNotes",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Vat = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    Items = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNotes", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryNotes",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Vat = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    SupplyDate = table.Column<DateTime>(nullable: true),
                    Items = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryNotes", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "DocItemEntity",
                columns: table => new
                {
                    DocKey = table.Column<long>(nullable: false),
                    ItemNumber = table.Column<int>(nullable: false),
                    VisualOrder = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    IsOpen = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    OpenQuantity = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    Currency = table.Column<string>(nullable: true),
                    PricePerQuantity = table.Column<decimal>(type: "decimal(10,3)", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    BaseDoc = table.Column<string>(nullable: true),
                    BaseItemNumber = table.Column<int>(nullable: true),
                    FollowDoc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocItemEntity", x => new { x.DocKey, x.ItemNumber });
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTimeClocks",
                columns: table => new
                {
                    Key = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeSn = table.Column<int>(nullable: false),
                    CheckIn = table.Column<DateTimeOffset>(nullable: false),
                    CheckOut = table.Column<DateTimeOffset>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    CheckInLocation = table.Column<string>(nullable: true),
                    CheckOutLocation = table.Column<string>(nullable: true),
                    Properties = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTimeClocks", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmpId = table.Column<int>(nullable: false),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Vat = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    Items = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "JobPosition",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPosition", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LeadUserData",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LeadSn = table.Column<string>(nullable: false),
                    IsRead = table.Column<bool>(nullable: false),
                    IsFavorite = table.Column<bool>(nullable: false),
                    LastModifiedUtc = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadUserData", x => new { x.UserId, x.LeadSn });
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Vat = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    SupplyDate = table.Column<DateTime>(nullable: true),
                    Items = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PictureURL = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: true),
                    LastUpdateDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    GroupCode = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NameForeign = table.Column<string>(nullable: true),
                    Barcode = table.Column<string>(nullable: true),
                    PictureURL = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    IsForSell = table.Column<bool>(nullable: false),
                    IsForBuy = table.Column<bool>(nullable: false),
                    Properties = table.Column<string>(nullable: true),
                    AutoQuantityCalculationExpression = table.Column<string>(nullable: true),
                    CreationDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    SellPriceList = table.Column<string>(nullable: true),
                    BuyPriceList = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Quotations",
                columns: table => new
                {
                    Key = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    Vat = table.Column<decimal>(type: "decimal(10,3)", nullable: true),
                    ValidUntil = table.Column<DateTime>(nullable: true),
                    Items = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotations", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    JwtId = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    IsUsed = table.Column<bool>(nullable: false),
                    IsInvalidated = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    SN = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ActiveStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.SN);
                });

            migrationBuilder.CreateTable(
                name: "UserLocations",
                columns: table => new
                {
                    Key = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeSn = table.Column<int>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    ErrorCode = table.Column<int>(nullable: true),
                    DeviceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLocations", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    FederalTaxID = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true),
                    AddressID = table.Column<string>(nullable: true),
                    DefaultCurrency = table.Column<string>(nullable: true),
                    VatPercent = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    WebSite = table.Column<string>(nullable: true),
                    Phone1 = table.Column<string>(nullable: true),
                    Phone2 = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    BankAccount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Companies_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Sn = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ID = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: true),
                    JobTitle = table.Column<string>(nullable: true),
                    DepartmentCode = table.Column<int>(nullable: true),
                    PositionCode = table.Column<int>(nullable: true),
                    ManagerSN = table.Column<int>(nullable: true),
                    SalesmanSN = table.Column<int>(nullable: true),
                    HomeAddressForeignKey = table.Column<string>(nullable: true),
                    WorkAddressForeignKey = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    OfficePhone = table.Column<string>(nullable: true),
                    WorkCellular = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PicPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Sn);
                    table.ForeignKey(
                        name: "FK_Employees_Department_DepartmentCode",
                        column: x => x.DepartmentCode,
                        principalTable: "Department",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Address_HomeAddressForeignKey",
                        column: x => x.HomeAddressForeignKey,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_JobPosition_PositionCode",
                        column: x => x.PositionCode,
                        principalTable: "JobPosition",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Address_WorkAddressForeignKey",
                        column: x => x.WorkAddressForeignKey,
                        principalTable: "Address",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_AddressID",
                table: "Companies",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentCode",
                table: "Employees",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HomeAddressForeignKey",
                table: "Employees",
                column: "HomeAddressForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionCode",
                table: "Employees",
                column: "PositionCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkAddressForeignKey",
                table: "Employees",
                column: "WorkAddressForeignKey");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountBalanceRecords");

            migrationBuilder.DropTable(
                name: "BankEntity");

            migrationBuilder.DropTable(
                name: "BusinessPartners");

            migrationBuilder.DropTable(
                name: "CardGroups");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "CreditNotes");

            migrationBuilder.DropTable(
                name: "DeliveryNotes");

            migrationBuilder.DropTable(
                name: "DocItemEntity");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeTimeClocks");

            migrationBuilder.DropTable(
                name: "IdentityUsers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "LeadUserData");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductGroups");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Quotations");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Salesmen");

            migrationBuilder.DropTable(
                name: "UserLocations");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "JobPosition");
        }
    }
}
