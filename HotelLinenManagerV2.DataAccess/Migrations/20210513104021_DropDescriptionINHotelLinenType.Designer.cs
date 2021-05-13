﻿// <auto-generated />
using System;
using HotelLinenManagerV2.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelLinenManagerV2.DataAccess.Migrations
{
    [DbContext(typeof(WarehauseStorageHotelLinenContext))]
    [Migration("20210513104021_DropDescriptionINHotelLinenType")]
    partial class DropDescriptionINHotelLinenType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<short>("Amount")
                        .HasColumnType("smallint");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PricePerKg")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Tax")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("WarehauseId")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("WarehauseId")
                        .IsUnique();

                    b.ToTable("HotelLinens");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinenType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PricePerKg")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Tax")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("HotelLinenTypes");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.Property<int>("PositionType")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Warehause", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WarehauseNumber")
                        .HasColumnType("int");

                    b.Property<byte>("WarehauseType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Warehauses");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Company", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Invoice", null)
                        .WithMany("Company")
                        .HasForeignKey("InvoiceId");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Invoice", null)
                        .WithMany("HotelLinen")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Warehause", "Warehause")
                        .WithOne("HotelLinen")
                        .HasForeignKey("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", "WarehauseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Warehause");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.User", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Warehause", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Invoice", b =>
                {
                    b.Navigation("Company");

                    b.Navigation("HotelLinen");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Warehause", b =>
                {
                    b.Navigation("HotelLinen");
                });
#pragma warning restore 612, 618
        }
    }
}
