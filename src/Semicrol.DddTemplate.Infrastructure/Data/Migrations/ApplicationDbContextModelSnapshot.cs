﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Semicrol.DddTemplate.Infrastructure.Data;

#nullable disable

namespace Semicrol.DddTemplate.Infrastructure.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Semicrol.DddTemplate.Core.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Semicrol.DddTemplate.Core.Products.Product", b =>
                {
                    b.OwnsOne("Semicrol.DddTemplate.Core.Common.ValueObjects.Ratings", "Ratings", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.ToJson("Ratings");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");

                            b1.OwnsMany("Semicrol.DddTemplate.Core.Common.ValueObjects.Rating", "Values", b2 =>
                                {
                                    b2.Property<Guid>("RatingsProductId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("int");

                                    b2.Property<DateTime>("Date")
                                        .HasColumnType("datetime2");

                                    b2.Property<string>("User")
                                        .HasColumnType("nvarchar(max)");

                                    b2.Property<int>("Value")
                                        .HasColumnType("int");

                                    b2.HasKey("RatingsProductId", "Id");

                                    b2.ToTable("Products");

                                    b2.WithOwner()
                                        .HasForeignKey("RatingsProductId");
                                });

                            b1.Navigation("Values");
                        });

                    b.OwnsOne("Semicrol.DddTemplate.Core.Products.ValueObjects.ProductInfo", "Information", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Products");

                            b1.ToJson("Information");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.Navigation("Information");

                    b.Navigation("Ratings");
                });
#pragma warning restore 612, 618
        }
    }
}
