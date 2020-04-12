using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagerAssistant.Data.Migrations
{
    public partial class ManagerAssistant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FIO = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    NuberTelephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NameOrganization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FIO = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    NumberTelephone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DataEmployment = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    DesignerPosition = table.Column<string>(nullable: true),
                    Salary = table.Column<double>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    DevPosition = table.Column<string>(nullable: true),
                    Developer_Salary = table.Column<double>(nullable: true),
                    Developer_Status = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Salare = table.Column<double>(nullable: true),
                    OtherEmloyee_Status = table.Column<string>(nullable: true),
                    TesterPosition = table.Column<string>(nullable: true),
                    Tester_Salary = table.Column<double>(nullable: true),
                    Tester_Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderName = table.Column<string>(nullable: true),
                    DateOrder = table.Column<DateTime>(nullable: true),
                    DeadLineProject = table.Column<DateTime>(nullable: true),
                    CostProject = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TableForEmployee",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Changes = table.Column<string>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: true),
                    DateEnd = table.Column<DateTime>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    TemplateDesign = table.Column<string>(nullable: true),
                    StatmentColor = table.Column<string>(nullable: true),
                    PervisionTerm = table.Column<DateTime>(nullable: true),
                    DateWork = table.Column<DateTime>(nullable: true),
                    DateDev = table.Column<DateTime>(nullable: true),
                    StepDev = table.Column<string>(nullable: true),
                    DateTest = table.Column<DateTime>(nullable: true),
                    IntegrationTest = table.Column<string>(nullable: true),
                    SystemTest = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TableForEmployee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NameProject = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DayOnDev = table.Column<int>(nullable: true),
                    Insurance = table.Column<int>(nullable: true),
                    TotalDeadline = table.Column<int>(nullable: true),
                    QuantityPerson = table.Column<int>(nullable: true),
                    Rent = table.Column<double>(nullable: true),
                    PaymentForServers = table.Column<double>(nullable: true),
                    Cost = table.Column<double>(nullable: true),
                    AverageIncome = table.Column<double>(nullable: true),
                    TotalIncome = table.Column<double>(nullable: true),
                    Profit = table.Column<double>(nullable: true),
                    Tax = table.Column<double>(nullable: true),
                    CostProject = table.Column<double>(nullable: true),
                    IdOrder = table.Column<Guid>(nullable: true),
                    IdEmployee = table.Column<Guid>(nullable: true),
                    IdClient = table.Column<Guid>(nullable: true),
                    IdLead = table.Column<Guid>(nullable: true),
                    EployeeId = table.Column<Guid>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true),
                    ClientId = table.Column<Guid>(nullable: true),
                    TableForEmployeeId = table.Column<Guid>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CustomerEvaluatate = table.Column<string>(nullable: true),
                    Quality = table.Column<string>(nullable: true),
                    TotalSum = table.Column<double>(nullable: true),
                    DeadlineAccording = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Employee_EployeeId",
                        column: x => x.EployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_TableForEmployee_TableForEmployeeId",
                        column: x => x.TableForEmployeeId,
                        principalTable: "TableForEmployee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_EployeeId",
                table: "Project",
                column: "EployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_OrderId",
                table: "Project",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_TableForEmployeeId",
                table: "Project",
                column: "TableForEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "TableForEmployee");
        }
    }
}
