﻿// <auto-generated />
using Mall.Domain.Entities;
using Mall.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Mall.Migrations
{
    [DbContext(typeof(MallDbContext))]
    partial class MallDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<decimal?>("Integral");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsLock");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Password")
                        .HasMaxLength(100);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("Photos")
                        .HasMaxLength(100);

                    b.Property<string>("Sex")
                        .HasMaxLength(10);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Mall_Account");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AliasName")
                        .HasMaxLength(10);

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("City")
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("DetailAddress")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(30);

                    b.Property<bool>("IsDefault");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("RecUser")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CreatorUserId");

                    b.ToTable("Mall_Address");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_AttachFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentType")
                        .IsRequired();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Describe");

                    b.Property<string>("FileName")
                        .IsRequired();

                    b.Property<string>("FilePath")
                        .IsRequired();

                    b.Property<string>("FileSize");

                    b.Property<string>("FileType")
                        .IsRequired();

                    b.Property<string>("ParentId");

                    b.HasKey("Id");

                    b.ToTable("Mall_AttachFile");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<int>("ItemStatus");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.HasKey("Id");

                    b.ToTable("Mall_Cart");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AllPrice");

                    b.Property<int>("CartId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Describe");

                    b.Property<int>("ItemNum");

                    b.Property<decimal>("ItemPrice");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("ProductId");

                    b.ToTable("Mall_CartItem");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<string>("Describe")
                        .HasMaxLength(1000);

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int?>("ParentId");

                    b.Property<int>("SortNo");

                    b.HasKey("Id");

                    b.ToTable("Mall_Category");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CStatus");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Mall_Comment");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Integral", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActDate");

                    b.Property<int>("CostType");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<decimal>("Current");

                    b.Property<int>("DeptId");

                    b.Property<string>("Describe");

                    b.Property<decimal>("Integral");

                    b.Property<string>("TypeName")
                        .IsRequired();

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Mall_Integral");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<decimal>("AllPrice");

                    b.Property<int>("CartId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("OrderNo")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("OrderStatus");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("CartId");

                    b.HasIndex("CreatorUserId");

                    b.HasIndex("LastModifierUserId");

                    b.ToTable("Mall_Order");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_OrderRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<int>("OrderId");

                    b.Property<int>("OrderStatus");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("Mall_OrderRecord");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<long?>("DeleterUserId");

                    b.Property<DateTime?>("DeletionTime");

                    b.Property<string>("Describe")
                        .HasMaxLength(1000);

                    b.Property<string>("ImgPic")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("ItemNo")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PStatus");

                    b.Property<decimal>("Price");

                    b.Property<int>("SaleNums");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Mall_Product");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Address", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Account", "User")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_CartItem", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mall.Domain.Entities.Mall_Account", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Mall.Domain.Entities.Mall_Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Comment", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Integral", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Account", "Account")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Order", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mall.Domain.Entities.Mall_Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mall.Domain.Entities.Mall_Account", "CreatorUser")
                        .WithMany()
                        .HasForeignKey("CreatorUserId");

                    b.HasOne("Mall.Domain.Entities.Mall_Account", "LastModifierUser")
                        .WithMany()
                        .HasForeignKey("LastModifierUserId");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_OrderRecord", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Product", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
