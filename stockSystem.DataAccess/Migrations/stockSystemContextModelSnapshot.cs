﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockSystem.dataAccess.context;

#nullable disable

namespace stockSystem.DataAccess.Migrations
{
    [DbContext(typeof(stockSystemContext))]
    partial class stockSystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockSystem.dataAccess.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("barcode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<string>("size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.HasIndex("userId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("StockSystem.dataAccess.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LastName = "Admin",
                            Name = "Super",
                            PasswordHash = new byte[] { 241, 148, 80, 39, 25, 52, 78, 65, 86, 153, 60, 223, 192, 190, 50, 41, 240, 2, 154, 29, 10, 202, 232, 70, 158, 72, 201, 175, 127, 168, 253, 86, 237, 68, 63, 138, 59, 167, 6, 229, 61, 193, 225, 173, 56, 17, 186, 130, 76, 45, 243, 29, 25, 164, 220, 9, 135, 58, 21, 155, 204, 49, 229, 18 },
                            PasswordSalt = new byte[] { 223, 118, 20, 41, 18, 253, 50, 184, 19, 132, 214, 141, 239, 198, 4, 195, 15, 187, 29, 228, 164, 36, 4, 20, 6, 177, 26, 34, 95, 141, 131, 218, 35, 205, 252, 37, 196, 198, 207, 42, 60, 198, 73, 142, 88, 26, 119, 205, 123, 227, 100, 43, 77, 152, 111, 163, 49, 106, 146, 158, 47, 144, 144, 100, 41, 160, 102, 187, 69, 242, 131, 18, 25, 201, 110, 0, 163, 94, 22, 169, 149, 21, 101, 121, 251, 194, 243, 11, 189, 189, 244, 205, 182, 210, 36, 201, 11, 54, 175, 215, 80, 181, 7, 8, 209, 111, 62, 39, 220, 210, 15, 159, 140, 109, 113, 200, 153, 226, 59, 96, 210, 187, 50, 181, 128, 28, 129, 156 },
                            RolId = 1,
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("stockSystem.DataAccess.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "Alimento"
                        },
                        new
                        {
                            id = 2,
                            name = "Ropa"
                        },
                        new
                        {
                            id = 3,
                            name = "Juguetes"
                        });
                });

            modelBuilder.Entity("stockSystem.DataAccess.Models.Rol", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Rols");

                    b.HasData(
                        new
                        {
                            id = 1,
                            name = "ADMIN"
                        },
                        new
                        {
                            id = 2,
                            name = "SALESMAN"
                        },
                        new
                        {
                            id = 3,
                            name = "STOCKER"
                        });
                });

            modelBuilder.Entity("stockSystem.DataAccess.Models.Sales", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("salesBy")
                        .HasColumnType("int");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("id");

                    b.HasIndex("salesBy");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("stockSystem.DataAccess.Models.SalesDetail", b =>
                {
                    b.Property<int>("salesId")
                        .HasColumnType("int");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("salesId", "productId");

                    b.HasIndex("productId");

                    b.ToTable("SalesDetails", (string)null);
                });

            modelBuilder.Entity("StockSystem.dataAccess.Models.Product", b =>
                {
                    b.HasOne("stockSystem.DataAccess.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockSystem.dataAccess.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("user");
                });

            modelBuilder.Entity("StockSystem.dataAccess.Models.User", b =>
                {
                    b.HasOne("stockSystem.DataAccess.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("stockSystem.DataAccess.Models.Sales", b =>
                {
                    b.HasOne("StockSystem.dataAccess.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("salesBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("stockSystem.DataAccess.Models.SalesDetail", b =>
                {
                    b.HasOne("StockSystem.dataAccess.Models.Product", "products")
                        .WithMany("salesDetails")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("stockSystem.DataAccess.Models.Sales", "sales")
                        .WithMany("salesDetails")
                        .HasForeignKey("salesId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("products");

                    b.Navigation("sales");
                });

            modelBuilder.Entity("StockSystem.dataAccess.Models.Product", b =>
                {
                    b.Navigation("salesDetails");
                });

            modelBuilder.Entity("stockSystem.DataAccess.Models.Sales", b =>
                {
                    b.Navigation("salesDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
