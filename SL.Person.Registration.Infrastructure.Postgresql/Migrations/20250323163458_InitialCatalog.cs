using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SL.Person.Registration.Infrastructure.Postgresql.Migrations
{
    /// <inheritdoc />
    public partial class InitialCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ZipCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Street = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Number = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    Neighborhood = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Complement = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    State = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    PersonRegistrationId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonRegistrationId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Presence = table.Column<bool>(type: "boolean", nullable: false),
                    PersonRegistrationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DDD = table.Column<int>(type: "integer", maxLength: 2, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    PersonRegistrationId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonRegistrationId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonRegistrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    BithDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 20, nullable: false),
                    DocumentNumber = table.Column<long>(type: "bigint", nullable: false),
                    AddressId = table.Column<Guid>(type: "uuid", nullable: true),
                    ContactId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsExcluded = table.Column<bool>(type: "boolean", nullable: false),
                    InterviewerId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRegistrations_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PersonRegistrations_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TreatmentType = table.Column<int>(type: "integer", maxLength: 15, nullable: false),
                    WeakDayType = table.Column<int>(type: "integer", maxLength: 15, nullable: false),
                    InterviewType = table.Column<int>(type: "integer", maxLength: 15, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 15, nullable: false),
                    Status = table.Column<int>(type: "integer", maxLength: 15, nullable: false),
                    InterviewerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    Opinion = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                    PersonRegistrationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviews_PersonRegistrations_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interviews_PersonRegistrations_PersonRegistrationId",
                        column: x => x.PersonRegistrationId,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonRegistrationPersonTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonRegistrationId = table.Column<Guid>(type: "uuid", nullable: false),
                    PersonTypeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonRegistrationPersonTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonRegistrationPersonTypes_PersonRegistrations_PersonReg~",
                        column: x => x.PersonRegistrationId,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonRegistrationPersonTypes_PersonTypes_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    WeakDayType = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DoTheReading = table.Column<bool>(type: "boolean", nullable: false),
                    PersonRegistrationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkSchedules_PersonRegistrations_PersonRegistrationId",
                        column: x => x.PersonRegistrationId,
                        principalTable: "PersonRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trataments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Presence = table.Column<bool>(type: "boolean", nullable: true),
                    InterviewId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trataments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trataments_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03b340ee-292c-412a-b909-386eda4d99e3"), "Assistido" },
                    { new Guid("21a7e47d-4781-48cc-a587-dfd55c5581e6"), "Palestrante" },
                    { new Guid("35b731eb-0895-4a94-86b0-4436fd80db4c"), "Tarefeiro" },
                    { new Guid("87565733-c273-4163-90b5-081ecc354170"), "Todos" },
                    { new Guid("dbacb66e-e460-48a8-b4e7-bbb6852859d9"), "Entrevistador" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonRegistrationId1",
                table: "Addresses",
                column: "PersonRegistrationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_PersonRegistrationId",
                table: "Assignments",
                column: "PersonRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PersonRegistrationId1",
                table: "Contacts",
                column: "PersonRegistrationId1");

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewerId",
                table: "Interviews",
                column: "InterviewerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_PersonRegistrationId",
                table: "Interviews",
                column: "PersonRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrationPersonTypes_PersonRegistrationId",
                table: "PersonRegistrationPersonTypes",
                column: "PersonRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrationPersonTypes_PersonTypeId",
                table: "PersonRegistrationPersonTypes",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrations_AddressId",
                table: "PersonRegistrations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonRegistrations_ContactId",
                table: "PersonRegistrations",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Trataments_InterviewId",
                table: "Trataments",
                column: "InterviewId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSchedules_PersonRegistrationId",
                table: "WorkSchedules",
                column: "PersonRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_PersonRegistrations_PersonRegistrationId1",
                table: "Addresses",
                column: "PersonRegistrationId1",
                principalTable: "PersonRegistrations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_PersonRegistrations_PersonRegistrationId",
                table: "Assignments",
                column: "PersonRegistrationId",
                principalTable: "PersonRegistrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_PersonRegistrations_PersonRegistrationId1",
                table: "Contacts",
                column: "PersonRegistrationId1",
                principalTable: "PersonRegistrations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PersonRegistrations_PersonRegistrationId1",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_PersonRegistrations_PersonRegistrationId1",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "PersonRegistrationPersonTypes");

            migrationBuilder.DropTable(
                name: "Trataments");

            migrationBuilder.DropTable(
                name: "WorkSchedules");

            migrationBuilder.DropTable(
                name: "PersonTypes");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "PersonRegistrations");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
