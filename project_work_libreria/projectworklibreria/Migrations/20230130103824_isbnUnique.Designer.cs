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
    [Migration("20230130103824_isbnUnique")]
    partial class isbnUnique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("project_work_libreria.Models.Genere", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NewGenere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genere");
                });

            modelBuilder.Entity("project_work_libreria.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenereId")
                        .HasColumnType("int");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("Like")
                        .HasColumnType("int");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.Property<int?>("Quantita")
                        .HasColumnType("int");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GenereId");

                    b.HasIndex("Isbn")
                        .IsUnique();

                    b.ToTable("Libri");
                });

            modelBuilder.Entity("project_work_libreria.Models.Libro", b =>
                {
                    b.HasOne("project_work_libreria.Models.Genere", "Genere")
                        .WithMany()
                        .HasForeignKey("GenereId");

                    b.Navigation("Genere");
                });
#pragma warning restore 612, 618
        }
    }
}
