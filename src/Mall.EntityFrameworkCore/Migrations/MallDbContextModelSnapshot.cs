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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<DateTime>("CreationTime");

                    b.Property<long?>("CreatorUserId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsLock");

                    b.Property<DateTime?>("LastModificationTime");

                    b.Property<long?>("LastModifierUserId");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Mall_Account");
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

                    b.Property<int>("ItemNum");

                    b.Property<decimal>("ItemPrice");

                    b.Property<int>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

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

                    b.HasKey("Id");

                    b.ToTable("Mall_Category");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

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

                    b.HasIndex("CartId");

                    b.ToTable("Mall_Order");
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

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Mall_Product");
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_CartItem", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Mall.Domain.Entities.Mall_Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Mall.Domain.Entities.Mall_Order", b =>
                {
                    b.HasOne("Mall.Domain.Entities.Mall_Cart", "Cart")
                        .WithMany()
                        .HasForeignKey("CartId")
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
