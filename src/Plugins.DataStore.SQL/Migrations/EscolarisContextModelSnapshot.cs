﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Plugins.DataStore.SQL;

#nullable disable

namespace Plugins.DataStore.SQL.Migrations
{
    [DbContext(typeof(EscolarisContext))]
    partial class EscolarisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoreBusiness.AcadProgram", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProgramId"));

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Price")
                        .IsRequired()
                        .HasColumnType("float");

                    b.Property<int?>("Quantity")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ProgramId");

                    b.HasIndex("CategoryId");

                    b.ToTable("AcadPrograms");

                    b.HasData(
                        new
                        {
                            ProgramId = 1,
                            CategoryId = 1,
                            Name = "System Engineering",
                            Price = 17.989999999999998,
                            Quantity = 30
                        },
                        new
                        {
                            ProgramId = 2,
                            CategoryId = 1,
                            Name = "Mathematic",
                            Price = 8.9900000000000002,
                            Quantity = 20
                        },
                        new
                        {
                            ProgramId = 3,
                            CategoryId = 2,
                            Name = "Specilization in Biology",
                            Price = 12.5,
                            Quantity = 25
                        },
                        new
                        {
                            ProgramId = 4,
                            CategoryId = 2,
                            Name = "Master in Education",
                            Price = 5.5,
                            Quantity = 32
                        });
                });

            modelBuilder.Entity("CoreBusiness.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Description = "Pregrado",
                            Name = "Pregrado"
                        },
                        new
                        {
                            CategoryId = 2,
                            Description = "Postgrado",
                            Name = "Postgrado"
                        },
                        new
                        {
                            CategoryId = 3,
                            Description = "Educación Continúa",
                            Name = "Educación Continúa"
                        });
                });

            modelBuilder.Entity("CoreBusiness.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<int>("BeforeQty")
                        .HasColumnType("int");

                    b.Property<string>("CashierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<string>("ProgramName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoldQty")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("TransactionId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("CoreBusiness.AcadProgram", b =>
                {
                    b.HasOne("CoreBusiness.Category", "Category")
                        .WithMany("AcadPrograms")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CoreBusiness.Category", b =>
                {
                    b.Navigation("AcadPrograms");
                });
#pragma warning restore 612, 618
        }
    }
}
