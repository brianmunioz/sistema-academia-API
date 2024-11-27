using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sistema.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaPublicacion = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "instructores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Grado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "precios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR", maxLength: 250, nullable: true),
                    PrecioActual = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false),
                    PrecioPromocion = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_precios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "calificaciones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Alumno = table.Column<string>(type: "TEXT", nullable: true),
                    Puntaje = table.Column<int>(type: "INTEGER", nullable: false),
                    Comentario = table.Column<string>(type: "TEXT", nullable: true),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_calificaciones_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "imagenes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_imagenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_imagenes_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cursos_instructores",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    InstructorId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos_instructores", x => new { x.InstructorId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_cursos_instructores_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursos_instructores_instructores_InstructorId",
                        column: x => x.InstructorId,
                        principalTable: "instructores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cursos_precios",
                columns: table => new
                {
                    CursoId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PrecioId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cursos_precios", x => new { x.PrecioId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_cursos_precios_cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cursos_precios_precios_PrecioId",
                        column: x => x.PrecioId,
                        principalTable: "precios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cursos",
                columns: new[] { "Id", "Descripcion", "FechaPublicacion", "Titulo" },
                values: new object[,]
                {
                    { new Guid("1b0cead1-a0f6-4a1b-bb0b-3d11e641c489"), "The Football Is Good For Training And Recreational Purposes", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(1652), "Incredible Fresh Bacon" },
                    { new Guid("1d825d61-a5b2-4fe7-9173-a379e11c732b"), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(1771), "Handcrafted Metal Towels" },
                    { new Guid("21e79cb8-451b-4857-b7f3-936c8002d4ca"), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(1586), "Small Fresh Pizza" },
                    { new Guid("4f379161-ef65-44e7-b224-ccf2f54e44c6"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(1443), "Awesome Wooden Chicken" },
                    { new Guid("9d711dec-3442-4855-a3cb-492d523e9796"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(1743), "Handcrafted Plastic Bike" },
                    { new Guid("aa50a82c-1f9e-4a6f-9ce7-cec97dca668e"), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(1556), "Intelligent Fresh Ball" },
                    { new Guid("b014f01b-4efd-4f5f-ba3c-a0825c189d47"), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(1714), "Rustic Steel Table" },
                    { new Guid("cf12e676-3512-46c1-90e0-795c3c987199"), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(1611), "Ergonomic Cotton Pizza" },
                    { new Guid("dc4bf0fa-b30c-462e-8fd4-927c5fbee307"), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", new DateTime(2024, 11, 27, 3, 21, 35, 278, DateTimeKind.Utc).AddTicks(358), "Ergonomic Cotton Fish" }
                });

            migrationBuilder.InsertData(
                table: "instructores",
                columns: new[] { "Id", "Apellidos", "Grado", "Nombre" },
                values: new object[,]
                {
                    { new Guid("0ee0cd53-66fe-424d-8811-6bf9144dfa26"), "VonRueden", "National Quality Specialist", "Schuyler" },
                    { new Guid("509e6d3e-b0ec-4990-81b7-2379bee4b92e"), "Towne", "Dynamic Accounts Agent", "Stewart" },
                    { new Guid("5af6fb50-d1a2-468a-a9ba-244d7d7a75fe"), "O'Keefe", "District Accounts Supervisor", "Walter" },
                    { new Guid("648de723-7649-4fd2-b485-03b7b820aea7"), "Maggio", "Central Intranet Administrator", "Janet" },
                    { new Guid("8ced7dc0-52de-4ca5-a871-304f51f68c07"), "Macejkovic", "Direct Configuration Supervisor", "Ambrose" },
                    { new Guid("8d86db4d-8ae2-4609-a453-442bac91d966"), "Schoen", "Dynamic Directives Planner", "Corrine" },
                    { new Guid("a2b37818-c8d8-401f-b43c-b52ac5fd6b74"), "Konopelski", "Regional Security Strategist", "Keeley" },
                    { new Guid("b47100d6-7f22-486b-9346-0d14f05b9cba"), "Daugherty", "Lead Solutions Director", "Milo" },
                    { new Guid("d264d29d-0184-44b4-b502-592ca415c0f7"), "Lueilwitz", "Regional Solutions Administrator", "Jude" },
                    { new Guid("f94f7107-3079-4c15-ada8-95dfe37670d1"), "Swift", "Product Usability Consultant", "Angie" }
                });

            migrationBuilder.InsertData(
                table: "precios",
                columns: new[] { "Id", "Nombre", "PrecioActual", "PrecioPromocion" },
                values: new object[] { new Guid("3e7faabc-1d37-4ee8-a00a-8a4b083cfe5c"), "Precio standard", 10.0m, 8.0m });

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_CursoId",
                table: "calificaciones",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_instructores_CursoId",
                table: "cursos_instructores",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_cursos_precios_CursoId",
                table: "cursos_precios",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_imagenes_CursoId",
                table: "imagenes",
                column: "CursoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "cursos_instructores");

            migrationBuilder.DropTable(
                name: "cursos_precios");

            migrationBuilder.DropTable(
                name: "imagenes");

            migrationBuilder.DropTable(
                name: "instructores");

            migrationBuilder.DropTable(
                name: "precios");

            migrationBuilder.DropTable(
                name: "cursos");
        }
    }
}
