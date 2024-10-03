﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prueba_Tecnica_Integra.Data;

#nullable disable

namespace Prueba_Tecnica_Integra.Migrations
{
    [DbContext(typeof(PruebaTecnicaIntegraContext))]
    [Migration("20241003220622_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Prueba_Tecnica_Integra.Models.T_ARTÍCULO", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CodigoVenta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDProveedor")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Stock")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("IDProveedor");

                    b.ToTable("T_ARTÍCULO", (string)null);
                });

            modelBuilder.Entity("Prueba_Tecnica_Integra.Models.T_GRUPO_PROV", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("T_GRUPO_PROV", (string)null);
                });

            modelBuilder.Entity("Prueba_Tecnica_Integra.Models.T_PROVEEDOR", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IDGrupoProv")
                        .HasColumnType("int");

                    b.Property<string>("NIT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IDGrupoProv");

                    b.ToTable("T_PROVEEDOR", (string)null);
                });

            modelBuilder.Entity("Prueba_Tecnica_Integra.Models.T_ARTÍCULO", b =>
                {
                    b.HasOne("Prueba_Tecnica_Integra.Models.T_PROVEEDOR", "Proveedor")
                        .WithMany("Articulos")
                        .HasForeignKey("IDProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("Prueba_Tecnica_Integra.Models.T_PROVEEDOR", b =>
                {
                    b.HasOne("Prueba_Tecnica_Integra.Models.T_GRUPO_PROV", "GrupoProveedor")
                        .WithMany("Proveedores")
                        .HasForeignKey("IDGrupoProv")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GrupoProveedor");
                });

            modelBuilder.Entity("Prueba_Tecnica_Integra.Models.T_GRUPO_PROV", b =>
                {
                    b.Navigation("Proveedores");
                });

            modelBuilder.Entity("Prueba_Tecnica_Integra.Models.T_PROVEEDOR", b =>
                {
                    b.Navigation("Articulos");
                });
#pragma warning restore 612, 618
        }
    }
}
