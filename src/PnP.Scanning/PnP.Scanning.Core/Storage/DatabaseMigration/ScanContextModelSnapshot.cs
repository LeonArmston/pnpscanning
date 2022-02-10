﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PnP.Scanning.Core.Storage;

#nullable disable

namespace PnP.Scanning.Core.Storage.DatabaseMigration
{
    [DbContext(typeof(ScanContext))]
    partial class ScanContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("PnP.Scanning.Core.Storage.Cache", b =>
                {
                    b.Property<Guid>("ScanId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Key")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("ScanId", "Key");

                    b.HasIndex("ScanId", "Key")
                        .IsUnique();

                    b.ToTable("Cache");
                });

            modelBuilder.Entity("PnP.Scanning.Core.Storage.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Event")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ScanId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ScanId", "Event", "EventDate")
                        .IsUnique();

                    b.ToTable("History");
                });

            modelBuilder.Entity("PnP.Scanning.Core.Storage.Property", b =>
                {
                    b.Property<Guid>("ScanId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("ScanId", "Name");

                    b.HasIndex("ScanId", "Name")
                        .IsUnique();

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("PnP.Scanning.Core.Storage.Scan", b =>
                {
                    b.Property<Guid>("ScanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CLIApplicationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLIAuthMode")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLICertFile")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLICertFilePassword")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLICertPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLIEnvironment")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLIMode")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLISiteFile")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLISiteList")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLITenant")
                        .HasColumnType("TEXT");

                    b.Property<string>("CLITenantId")
                        .HasColumnType("TEXT");

                    b.Property<int>("CLIThreads")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("PreScanStatus")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Version")
                        .HasColumnType("TEXT");

                    b.HasKey("ScanId");

                    b.ToTable("Scans");
                });

            modelBuilder.Entity("PnP.Scanning.Core.Storage.SiteCollection", b =>
                {
                    b.Property<Guid>("ScanId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Error")
                        .HasColumnType("TEXT");

                    b.Property<string>("StackTrace")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("ScanId", "SiteUrl");

                    b.HasIndex("ScanId", "SiteUrl")
                        .IsUnique();

                    b.ToTable("SiteCollections");
                });

            modelBuilder.Entity("PnP.Scanning.Core.Storage.TestDelay", b =>
                {
                    b.Property<Guid>("ScanId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebUrl")
                        .HasColumnType("TEXT");

                    b.Property<int>("Delay1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Delay2")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Delay3")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WebIdString")
                        .HasColumnType("TEXT");

                    b.HasKey("ScanId", "SiteUrl", "WebUrl");

                    b.HasIndex("ScanId", "SiteUrl", "WebUrl")
                        .IsUnique();

                    b.ToTable("TestDelays");
                });

            modelBuilder.Entity("PnP.Scanning.Core.Storage.Web", b =>
                {
                    b.Property<Guid>("ScanId")
                        .HasColumnType("TEXT");

                    b.Property<string>("SiteUrl")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebUrl")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Error")
                        .HasColumnType("TEXT");

                    b.Property<string>("StackTrace")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Template")
                        .HasColumnType("TEXT");

                    b.HasKey("ScanId", "SiteUrl", "WebUrl");

                    b.HasIndex("ScanId", "SiteUrl", "WebUrl")
                        .IsUnique();

                    b.ToTable("Webs");
                });
#pragma warning restore 612, 618
        }
    }
}
