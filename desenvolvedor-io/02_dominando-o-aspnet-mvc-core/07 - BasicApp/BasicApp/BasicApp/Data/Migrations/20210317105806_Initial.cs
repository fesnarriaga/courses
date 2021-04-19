using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BasicApp.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DurationInMinutes = table.Column<int>(type: "int", nullable: true),
                    WorldwideBoxOfficeGross = table.Column<double>(type: "float", nullable: true),
                    NumberOfEpisodes = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Document = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    SupplierType = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    ProductionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0aadf706-0eae-478e-8dd9-d337463920d7"), "Robert Downey Jr." },
                    { new Guid("418a16a7-3ead-4488-af7c-66110d391d87"), "Melissa McBride" },
                    { new Guid("9177780c-7fa2-46b4-8883-e85d68826a91"), "Norman Reedus" },
                    { new Guid("3639dee6-db01-4a1f-b8d6-7f9800877feb"), "Hazuki Shimizu" },
                    { new Guid("b23c7a12-2deb-4a3f-97f6-e6350f4665ff"), "Matsuya Onoe" },
                    { new Guid("952c484e-383b-4a0e-9e23-090f01f3283f"), "Winona Ryder" },
                    { new Guid("6d3d82ac-1115-444f-bcf8-0e0518174125"), "Caleb McLaughlin" },
                    { new Guid("75a094a6-4e2c-4ab9-9197-d98c49e05978"), "Millie Bobby Brown" },
                    { new Guid("10a8d4a0-c526-4dd5-860a-8c4c1fd007dc"), "Karyn Parsons" },
                    { new Guid("04ff0e91-2ed6-4200-9f7a-caa5b47e9d4b"), "David Harbour" },
                    { new Guid("fad15e86-fb5c-4706-b3bd-97add48e77e1"), "Maggie Smith" },
                    { new Guid("3e9c60ac-9b0a-45bd-8a34-b17c09d5edae"), "Will Smith" },
                    { new Guid("a6a84308-efab-4f1d-b9c7-eab696f91f0a"), "Donny Yen" },
                    { new Guid("42defd05-818c-427b-a1ef-94b5e15d8256"), "Beyoncé" },
                    { new Guid("065a4f10-e46d-4502-ade8-f37d72d64d3b"), "Donald Glover" },
                    { new Guid("ec80a220-3c9d-498f-bbcf-d02a60389fa4"), "Danai Guira" },
                    { new Guid("a044553d-f3c0-48c2-8ded-160b409b5203"), "Chris Evans" },
                    { new Guid("42a9f2dc-ed81-47bc-86c9-37eab07352bf"), "Michelle Dockery" }
                });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "NumberOfEpisodes", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("96837c11-5528-4fab-9285-d4bd11b72a3d"), "Series", "Stranger Things", 34, new DateTime(2016, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("373914c9-b99f-48ff-a4ef-5486b1499b74"), "Series", "Downton Abbey", 52, new DateTime(2010, 9, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9dead2c1-a458-4fac-911f-f75b43dabb4c"), "Series", "The Fresh Prince of Bel-Air", 148, new DateTime(1990, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "DurationInMinutes", "Name", "ReleaseDate", "WorldwideBoxOfficeGross" },
                values: new object[,]
                {
                    { new Guid("594c3c95-71b5-497c-b8c1-cceb61ba55b2"), "Movie", 120, "Downton Abbey", new DateTime(2020, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 194051302.0 },
                    { new Guid("a669c9e6-5cfe-44cf-a27e-4a07ec71678e"), "Movie", 181, "Avengers: Endgame", new DateTime(2019, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2797800564.0 },
                    { new Guid("c726bf0e-79ab-4e81-9825-b30b690ba77f"), "Movie", 105, "Ip Man 4", new DateTime(2019, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 192617891.0 },
                    { new Guid("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"), "Movie", 118, "The Lion King", new DateTime(2019, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1654791102.0 }
                });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "NumberOfEpisodes", "ReleaseDate" },
                values: new object[] { new Guid("a007ab4a-a257-409a-a32c-a5a3a1e053ed"), "Series", "Kantaro: The Sweet Tooth Salaryman", 12, new DateTime(2017, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "DurationInMinutes", "Name", "ReleaseDate", "WorldwideBoxOfficeGross" },
                values: new object[] { new Guid("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5"), "Movie", 116, "Gemini Man", new DateTime(2019, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 166623705.0 });

            migrationBuilder.InsertData(
                table: "Productions",
                columns: new[] { "Id", "Discriminator", "Name", "NumberOfEpisodes", "ReleaseDate" },
                values: new object[] { new Guid("2d83a109-1fb4-4f63-98d5-f838bdd73d98"), "Series", "The Walking Dead", 177, new DateTime(2010, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "ActorId", "Name", "ProductionId" },
                values: new object[,]
                {
                    { new Guid("a4fe1159-01ff-430c-9059-20926501a4d3"), new Guid("0aadf706-0eae-478e-8dd9-d337463920d7"), "Tony Stark", new Guid("a669c9e6-5cfe-44cf-a27e-4a07ec71678e") },
                    { new Guid("709ff826-52ba-4a51-860e-43c65649ca72"), new Guid("418a16a7-3ead-4488-af7c-66110d391d87"), "Carol Peletier", new Guid("2d83a109-1fb4-4f63-98d5-f838bdd73d98") },
                    { new Guid("aafae44d-08d1-4327-a1d3-ff4fdb2c1daf"), new Guid("ec80a220-3c9d-498f-bbcf-d02a60389fa4"), "Michonne", new Guid("2d83a109-1fb4-4f63-98d5-f838bdd73d98") },
                    { new Guid("a95365b4-f9af-44d5-9080-b195ea54280e"), new Guid("9177780c-7fa2-46b4-8883-e85d68826a91"), "Daryl Dixon", new Guid("2d83a109-1fb4-4f63-98d5-f838bdd73d98") },
                    { new Guid("ae630bef-0bee-4cb1-842b-acfb63d53859"), new Guid("3639dee6-db01-4a1f-b8d6-7f9800877feb"), "Sano Erika", new Guid("a007ab4a-a257-409a-a32c-a5a3a1e053ed") },
                    { new Guid("fde7b141-7112-47be-825b-ea348baff5fa"), new Guid("b23c7a12-2deb-4a3f-97f6-e6350f4665ff"), "Ametani Kantarou", new Guid("a007ab4a-a257-409a-a32c-a5a3a1e053ed") },
                    { new Guid("51d36164-2593-4ebf-97eb-05aca8946502"), new Guid("04ff0e91-2ed6-4200-9f7a-caa5b47e9d4b"), "Jim Hopper", new Guid("96837c11-5528-4fab-9285-d4bd11b72a3d") },
                    { new Guid("e79cb17c-03ac-43cd-9d5c-634b46420dda"), new Guid("952c484e-383b-4a0e-9e23-090f01f3283f"), "Joyce Byers", new Guid("96837c11-5528-4fab-9285-d4bd11b72a3d") },
                    { new Guid("9ff37dc2-16c9-4842-9a90-9c027e0f3820"), new Guid("6d3d82ac-1115-444f-bcf8-0e0518174125"), "Lucas", new Guid("96837c11-5528-4fab-9285-d4bd11b72a3d") },
                    { new Guid("6ed7e268-a25e-41a0-a12c-774e19d0a8e9"), new Guid("75a094a6-4e2c-4ab9-9197-d98c49e05978"), "Eleven", new Guid("96837c11-5528-4fab-9285-d4bd11b72a3d") },
                    { new Guid("72e8841c-6370-4aa0-b48e-6b5373f133e1"), new Guid("42a9f2dc-ed81-47bc-86c9-37eab07352bf"), "Lady Mary Crawley", new Guid("373914c9-b99f-48ff-a4ef-5486b1499b74") },
                    { new Guid("3b5e90d8-c25b-4b73-a889-121bdf0e6ef9"), new Guid("fad15e86-fb5c-4706-b3bd-97add48e77e1"), "Violet Crawley", new Guid("373914c9-b99f-48ff-a4ef-5486b1499b74") },
                    { new Guid("800afaf3-6a13-4be0-9e36-f8c4848c48f8"), new Guid("3e9c60ac-9b0a-45bd-8a34-b17c09d5edae"), "Will Smith", new Guid("9dead2c1-a458-4fac-911f-f75b43dabb4c") },
                    { new Guid("fbbc4e14-4d23-4414-ba19-4932a2c6adff"), new Guid("42a9f2dc-ed81-47bc-86c9-37eab07352bf"), "Lady Mary Crawley", new Guid("594c3c95-71b5-497c-b8c1-cceb61ba55b2") },
                    { new Guid("b00ad210-f917-4c20-bc5f-03be6f8f6540"), new Guid("fad15e86-fb5c-4706-b3bd-97add48e77e1"), "Violet Crawley", new Guid("594c3c95-71b5-497c-b8c1-cceb61ba55b2") },
                    { new Guid("07c880ab-73e4-4636-9d5c-749152ea3923"), new Guid("3e9c60ac-9b0a-45bd-8a34-b17c09d5edae"), "Henry Brogan", new Guid("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5") },
                    { new Guid("2f83add8-6242-43aa-82f0-2a16cbdb7890"), new Guid("10a8d4a0-c526-4dd5-860a-8c4c1fd007dc"), "Hilary Banks", new Guid("9dead2c1-a458-4fac-911f-f75b43dabb4c") },
                    { new Guid("43a4e0b1-3a3f-4ae8-8e2d-77c0c822141c"), new Guid("42defd05-818c-427b-a1ef-94b5e15d8256"), "Nala", new Guid("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688") },
                    { new Guid("ba3d2449-3ec3-4308-a9bc-2fcdd352459a"), new Guid("a044553d-f3c0-48c2-8ded-160b409b5203"), "Steve Rogers", new Guid("a669c9e6-5cfe-44cf-a27e-4a07ec71678e") },
                    { new Guid("b3f18f9a-bf4d-4236-93a4-7318c189b864"), new Guid("ec80a220-3c9d-498f-bbcf-d02a60389fa4"), "Okoye", new Guid("a669c9e6-5cfe-44cf-a27e-4a07ec71678e") },
                    { new Guid("e2c339da-6533-47cb-937c-c58bbe4ff096"), new Guid("065a4f10-e46d-4502-ade8-f37d72d64d3b"), "Simba", new Guid("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688") },
                    { new Guid("e2f1e8cd-4d7d-4ec6-ae05-b0251f89f60d"), new Guid("a6a84308-efab-4f1d-b9c7-eab696f91f0a"), "Ip Man", new Guid("c726bf0e-79ab-4e81-9825-b30b690ba77f") }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[,]
                {
                    { new Guid("fe8bae04-d4e8-43a7-a4b6-375107a1092f"), new Guid("c726bf0e-79ab-4e81-9825-b30b690ba77f"), "Magazine", 1 },
                    { new Guid("4752c3b2-a097-44f3-b9f2-0b82cf1a58e4"), new Guid("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"), "Internet", 4 },
                    { new Guid("16b3196b-2646-434d-bba0-7329efb5f517"), new Guid("96837c11-5528-4fab-9285-d4bd11b72a3d"), "Internet", 1 },
                    { new Guid("3a1dd27c-352a-4628-a740-243266429605"), new Guid("96837c11-5528-4fab-9285-d4bd11b72a3d"), "Magazine", 4 },
                    { new Guid("3c7374ad-1549-4d76-a1a4-be4684e14ef8"), new Guid("96837c11-5528-4fab-9285-d4bd11b72a3d"), "Internet", 4 },
                    { new Guid("93ba8bd2-06fc-458d-bd1a-8ba41caf10ce"), new Guid("a669c9e6-5cfe-44cf-a27e-4a07ec71678e"), "App", 1 },
                    { new Guid("fef5fdd6-b9e8-4c72-b9cd-b0ca5df18605"), new Guid("a007ab4a-a257-409a-a32c-a5a3a1e053ed"), "Magazine", 4 },
                    { new Guid("c98c5e32-1c36-44c7-9b8e-4eb12e48966f"), new Guid("a007ab4a-a257-409a-a32c-a5a3a1e053ed"), "Magazine", 4 },
                    { new Guid("6c2ffdeb-1f08-4100-a5d8-c279682fe586"), new Guid("a007ab4a-a257-409a-a32c-a5a3a1e053ed"), "Newspaper", 4 },
                    { new Guid("669c5461-38bd-4566-b207-78a048385813"), new Guid("a007ab4a-a257-409a-a32c-a5a3a1e053ed"), "Newspaper", 4 },
                    { new Guid("5e00af09-f77d-4722-a7a7-c01c875767f0"), new Guid("a669c9e6-5cfe-44cf-a27e-4a07ec71678e"), "App", 3 },
                    { new Guid("279ec745-fdd9-4644-bdf5-6f2c02a58d92"), new Guid("2d83a109-1fb4-4f63-98d5-f838bdd73d98"), "Newspaper", 4 },
                    { new Guid("96a30668-3def-4a9e-84aa-a45422320ae0"), new Guid("2d83a109-1fb4-4f63-98d5-f838bdd73d98"), "App", 2 },
                    { new Guid("a1323f6b-8c23-4052-95c3-d85870d5bc96"), new Guid("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"), "Magazine", 3 },
                    { new Guid("d91a9097-65b2-4aa0-afb2-32fcbf6be0a7"), new Guid("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"), "Internet", 4 },
                    { new Guid("3a1f3eba-3f23-49fa-a76b-f06d97cf9ec3"), new Guid("373914c9-b99f-48ff-a4ef-5486b1499b74"), "Magazine", 4 },
                    { new Guid("d09c361f-0ed7-4b2b-b12c-e27ecc92552d"), new Guid("373914c9-b99f-48ff-a4ef-5486b1499b74"), "Internet", 1 },
                    { new Guid("df8d7565-8691-43c0-9252-3eeb59e4f946"), new Guid("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5"), "Newspaper", 2 },
                    { new Guid("94dab8d0-e6c4-4753-85bb-0d1aa98f703e"), new Guid("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5"), "Magazine", 4 },
                    { new Guid("33bf6942-1209-400e-996d-9378286ddb93"), new Guid("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5"), "Internet", 3 }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "Id", "ProductionId", "Source", "Stars" },
                values: new object[,]
                {
                    { new Guid("bf4424b7-9af3-43fe-b7a3-a206654e27ea"), new Guid("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5"), "App", 4 },
                    { new Guid("d4ed3c43-e34b-47a3-82ed-a1ff4af6c5a6"), new Guid("7668cedc-9cc1-4ca3-a7a5-22d8e9439ef5"), "Newspaper", 3 },
                    { new Guid("0477e936-ee86-460a-84fb-17c67f800347"), new Guid("c726bf0e-79ab-4e81-9825-b30b690ba77f"), "Magazine", 2 },
                    { new Guid("85ffe2d4-4c37-47a9-bd36-a21f33672c0f"), new Guid("c726bf0e-79ab-4e81-9825-b30b690ba77f"), "Newspaper", 1 },
                    { new Guid("1bea6cdd-385e-4b8a-ac43-d94eb6d4278b"), new Guid("594c3c95-71b5-497c-b8c1-cceb61ba55b2"), "Internet", 4 },
                    { new Guid("42a9b9b5-f181-4c9d-8858-99b66026ea6e"), new Guid("594c3c95-71b5-497c-b8c1-cceb61ba55b2"), "Magazine", 1 },
                    { new Guid("ba7e146c-c5bb-4c92-9c22-a00e3024ad73"), new Guid("2d83a109-1fb4-4f63-98d5-f838bdd73d98"), "Magazine", 2 },
                    { new Guid("35184bc9-e12a-4c64-9518-a10ecdd7bfcb"), new Guid("9dead2c1-a458-4fac-911f-f75b43dabb4c"), "Magazine", 5 },
                    { new Guid("a207a0a0-472a-4281-a17f-04734c82d7a6"), new Guid("9dead2c1-a458-4fac-911f-f75b43dabb4c"), "Newspaper", 3 },
                    { new Guid("0f6aa4e6-97c0-4837-b35f-8ede921f2cf9"), new Guid("9dead2c1-a458-4fac-911f-f75b43dabb4c"), "Newspaper", 3 },
                    { new Guid("469420a6-fdc4-4b59-9666-9ccd4b4511c5"), new Guid("9dead2c1-a458-4fac-911f-f75b43dabb4c"), "Magazine", 5 },
                    { new Guid("d7adba86-c2a6-4c94-a0c3-d9c502ef8275"), new Guid("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"), "App", 4 },
                    { new Guid("db6fee83-d919-499b-babd-4a0254399acc"), new Guid("1c23ba8f-1c5e-4db3-a7a7-bf0f4685b688"), "Newspaper", 1 },
                    { new Guid("3492a78e-4302-48a7-9ab2-12c1f5d4dbdd"), new Guid("373914c9-b99f-48ff-a4ef-5486b1499b74"), "App", 4 },
                    { new Guid("e12a1843-ec38-48c6-8e5a-501f8ba28586"), new Guid("c726bf0e-79ab-4e81-9825-b30b690ba77f"), "Internet", 4 },
                    { new Guid("4e365e20-636a-4b29-ac1c-80f90dce43c6"), new Guid("2d83a109-1fb4-4f63-98d5-f838bdd73d98"), "Magazine", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_SupplierId",
                table: "Addresses",
                column: "SupplierId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ActorId",
                table: "Characters",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ProductionId",
                table: "Characters",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductionId",
                table: "Ratings",
                column: "ProductionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Productions");
        }
    }
}
