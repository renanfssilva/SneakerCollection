﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SneakerCollection.Infrastructure.Persistence;

#nullable disable

namespace SneakerCollection.Infrastructure.Migrations
{
    [DbContext(typeof(SneakerCollectionDbContext))]
    partial class SneakerCollectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SneakerCollection.Domain.SneakerAggregate.Sneaker", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Rate")
                        .HasColumnType("int");

                    b.Property<double>("SizeUS")
                        .HasColumnType("float");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sneakers", (string)null);
                });

            modelBuilder.Entity("SneakerCollection.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

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
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("SneakerCollection.Domain.SneakerAggregate.Sneaker", b =>
                {
                    b.OwnsOne("SneakerCollection.Domain.SneakerAggregate.ValueObjects.Brand", "Brand", b1 =>
                        {
                            b1.Property<Guid>("SneakerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Brand_Name");

                            b1.HasKey("SneakerId");

                            b1.ToTable("Sneakers");

                            b1.WithOwner()
                                .HasForeignKey("SneakerId");
                        });

                    b.OwnsOne("SneakerCollection.Domain.SneakerAggregate.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("SneakerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("decimal(20,2)");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SneakerId");

                            b1.ToTable("Sneakers");

                            b1.WithOwner()
                                .HasForeignKey("SneakerId");
                        });

                    b.Navigation("Brand")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
