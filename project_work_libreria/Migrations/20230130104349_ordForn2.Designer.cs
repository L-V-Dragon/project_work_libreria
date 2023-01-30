﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_work_libreria.Database;

#nullable disable

namespace projectworklibreria.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    [Migration("20230130104349_ordForn2")]
    partial class ordForn2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("project_work_libreria.Models.Fornitore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Foprnitore");
                });

            modelBuilder.Entity("project_work_libreria.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("FornitoreId")
                        .HasColumnType("int");

                    b.Property<int?>("OrdineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FornitoreId");

                    b.HasIndex("OrdineId");

                    b.ToTable("Libri");
                });

            modelBuilder.Entity("project_work_libreria.Models.Ordine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("FornitoreId")
                        .HasColumnType("int");

                    b.Property<int>("Quantita")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FornitoreId");

                    b.ToTable("Ordine");
                });

            modelBuilder.Entity("project_work_libreria.Models.Libro", b =>
                {
                    b.HasOne("project_work_libreria.Models.Fornitore", null)
                        .WithMany("Libri")
                        .HasForeignKey("FornitoreId");

                    b.HasOne("project_work_libreria.Models.Ordine", null)
                        .WithMany("Libri")
                        .HasForeignKey("OrdineId");
                });

            modelBuilder.Entity("project_work_libreria.Models.Ordine", b =>
                {
                    b.HasOne("project_work_libreria.Models.Fornitore", "Fornitore")
                        .WithMany()
                        .HasForeignKey("FornitoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fornitore");
                });

            modelBuilder.Entity("project_work_libreria.Models.Fornitore", b =>
                {
                    b.Navigation("Libri");
                });

            modelBuilder.Entity("project_work_libreria.Models.Ordine", b =>
                {
                    b.Navigation("Libri");
                });
#pragma warning restore 612, 618
        }
    }
}
