﻿// <auto-generated />
using System;
using Assignment_2.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment_2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220527111740_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment_2.Models.Attribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("BatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.ToTable("Attribute");
                });

            modelBuilder.Entity("Assignment_2.Models.Batch", b =>
                {
                    b.Property<Guid>("BatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BatchPublishedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BusinessUnitId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BatchId");

                    b.HasIndex("BusinessUnitId");

                    b.ToTable("Batch");
                });

            modelBuilder.Entity("Assignment_2.Models.BusinessUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BusinessUnit");
                });

            modelBuilder.Entity("Assignment_2.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("BatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("Hash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MimeType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Assignment_2.Models.FileAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("BatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FileId")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("FileAttribute");
                });

            modelBuilder.Entity("Assignment_2.Models.ReadGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("BatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.ToTable("ReadGroup");
                });

            modelBuilder.Entity("Assignment_2.Models.ReadUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("BatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("User")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.ToTable("ReadUser");
                });

            modelBuilder.Entity("Assignment_2.Models.Attribute", b =>
                {
                    b.HasOne("Assignment_2.Models.Batch", null)
                        .WithMany("Attribute")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment_2.Models.Batch", b =>
                {
                    b.HasOne("Assignment_2.Models.BusinessUnit", "BusinessUnit")
                        .WithMany()
                        .HasForeignKey("BusinessUnitId");

                    b.Navigation("BusinessUnit");
                });

            modelBuilder.Entity("Assignment_2.Models.File", b =>
                {
                    b.HasOne("Assignment_2.Models.Batch", null)
                        .WithMany("Files")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment_2.Models.FileAttribute", b =>
                {
                    b.HasOne("Assignment_2.Models.File", null)
                        .WithMany("FileAttribute")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment_2.Models.ReadGroup", b =>
                {
                    b.HasOne("Assignment_2.Models.Batch", null)
                        .WithMany("ReadGroup")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment_2.Models.ReadUser", b =>
                {
                    b.HasOne("Assignment_2.Models.Batch", null)
                        .WithMany("ReadUser")
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment_2.Models.Batch", b =>
                {
                    b.Navigation("Attribute");

                    b.Navigation("Files");

                    b.Navigation("ReadGroup");

                    b.Navigation("ReadUser");
                });

            modelBuilder.Entity("Assignment_2.Models.File", b =>
                {
                    b.Navigation("FileAttribute");
                });
#pragma warning restore 612, 618
        }
    }
}