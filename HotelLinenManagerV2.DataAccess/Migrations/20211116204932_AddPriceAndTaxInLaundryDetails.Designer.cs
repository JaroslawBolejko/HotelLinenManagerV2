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
    [Migration("20211116204932_AddPriceAndTaxInLaundryDetails")]
    partial class AddPriceAndTaxInLaundryDetails
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

                    b.Property<string>("ApartmentNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EMail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("TelefonNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PricePerKg")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TypeName")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("HotelLinens");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfInvoice")
                        .HasColumnType("date");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("date");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("IssuedDate")
                        .HasColumnType("date");

                    b.Property<int?>("LaundryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Number")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("RecievedDate")
                        .HasColumnType("date");

                    b.Property<decimal>("TotalBrutto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalNetto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalTax")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("LaundryId");

                    b.ToTable("LaundryServices");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryServiceDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int>("LaundryServiceId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerKg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxValue")
                        .HasColumnType("int");

                    b.Property<double>("TotalWeight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("LaundryServiceId");

                    b.ToTable("LaundryServiceDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.PriceList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DocName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("bit");

                    b.Property<int?>("LaundryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LaundryId");

                    b.ToTable("PriceLists");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.PriceListDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int>("PriceListId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerKg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TaxValue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("PriceListId");

                    b.ToTable("PriceListDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.RelatedCompany", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("LaundryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("LaundryId");

                    b.ToTable("RelatedCompanies");
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

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Workplace")
                        .HasColumnType("int");

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
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("WarehauseNumber")
                        .HasColumnType("int");

                    b.Property<byte>("WarehauseType")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Warehauses");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.WarehauseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("HotelLinenId")
                        .HasColumnType("int");

                    b.Property<int>("WarehauseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelLinenId");

                    b.HasIndex("WarehauseId");

                    b.ToTable("WarehauseDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("HotelLinens")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryService", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("CompanyLaundryServices")
                        .HasForeignKey("CompanyId");

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Invoice", "Invoice")
                        .WithMany("LaundryServices")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Laundry")
                        .WithMany("LaundryLaundryServices")
                        .HasForeignKey("LaundryId");

                    b.Navigation("Company");

                    b.Navigation("Invoice");

                    b.Navigation("Laundry");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryServiceDetail", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany()
                        .HasForeignKey("HotelLinenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.LaundryService", "LaundryService")
                        .WithMany("LaundryServiceDetails")
                        .HasForeignKey("LaundryServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelLinen");

                    b.Navigation("LaundryService");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.PriceList", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("CompanyPriceLists")
                        .HasForeignKey("CompanyId");

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Laundry")
                        .WithMany("LaundryPriceLists")
                        .HasForeignKey("LaundryId");

                    b.Navigation("Company");

                    b.Navigation("Laundry");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.PriceListDetail", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("PriceListDetails")
                        .HasForeignKey("HotelLinenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.PriceList", "PriceList")
                        .WithMany("Details")
                        .HasForeignKey("PriceListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelLinen");

                    b.Navigation("PriceList");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.RelatedCompany", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("Companies")
                        .HasForeignKey("CompanyId");

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Laundry")
                        .WithMany("Laundries")
                        .HasForeignKey("LaundryId");

                    b.Navigation("Company");

                    b.Navigation("Laundry");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.User", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Warehause", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Company", "Company")
                        .WithMany("Warehauses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.WarehauseDetail", b =>
                {
                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", "HotelLinen")
                        .WithMany("WarehauseDetails")
                        .HasForeignKey("HotelLinenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HotelLinenManagerV2.DataAccess.Entities.Warehause", "Warehause")
                        .WithMany("WarehauseDetails")
                        .HasForeignKey("WarehauseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HotelLinen");

                    b.Navigation("Warehause");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Company", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("CompanyLaundryServices");

                    b.Navigation("CompanyPriceLists");

                    b.Navigation("HotelLinens");

                    b.Navigation("Laundries");

                    b.Navigation("LaundryLaundryServices");

                    b.Navigation("LaundryPriceLists");

                    b.Navigation("Users");

                    b.Navigation("Warehauses");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.HotelLinen", b =>
                {
                    b.Navigation("PriceListDetails");

                    b.Navigation("WarehauseDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Invoice", b =>
                {
                    b.Navigation("LaundryServices");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.LaundryService", b =>
                {
                    b.Navigation("LaundryServiceDetails");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.PriceList", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("HotelLinenManagerV2.DataAccess.Entities.Warehause", b =>
                {
                    b.Navigation("WarehauseDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
