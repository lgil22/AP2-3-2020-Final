﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulo",
                columns: table => new
                {
                    ArticulosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    CategoriaId = table.Column<int>(nullable: false),
                    Existencia = table.Column<int>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulo", x => x.ArticulosId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Celular = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Cobro",
                columns: table => new
                {
                    CobroId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    VentaId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<float>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobro", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    NombreUsuario = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Venta",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    TipoPago = table.Column<string>(nullable: true),
                    Balance = table.Column<decimal>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venta", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CobroId = table.Column<int>(nullable: false),
                    VentaId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    CobrosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CobrosDetalles_Cobro_CobrosId",
                        column: x => x.CobrosId,
                        principalTable: "Cobro",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalles",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalles", x => x.VentaId);
                    table.ForeignKey(
                        name: "FK_VentasDetalles_Venta_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Venta",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "UsuarioId", "Contrasena", "Email", "Fecha", "NombreUsuario", "Nombres" },
                values: new object[] { 1, "MQAyADMANAA=", "lgilbaez@gmail.com", new DateTime(2020, 12, 9, 7, 12, 15, 902, DateTimeKind.Local).AddTicks(9125), "Admin", "Luis" });

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalles_CobrosId",
                table: "CobrosDetalles",
                column: "CobrosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "CobrosDetalles");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "VentasDetalles");

            migrationBuilder.DropTable(
                name: "Cobro");

            migrationBuilder.DropTable(
                name: "Venta");
        }
    }
}
