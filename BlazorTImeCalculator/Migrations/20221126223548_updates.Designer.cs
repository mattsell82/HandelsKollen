﻿// <auto-generated />
using System;
using BlazorTimeCalculator.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorTimeCalculator.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221126223548_updates")]
    partial class updates
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.10");

            modelBuilder.Entity("BlazorTimeCalculator.Model.WorkReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("WorkReports");
                });

            modelBuilder.Entity("BlazorTimeCalculator.Model.WorkUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Lunch")
                        .HasColumnType("TEXT");

                    b.Property<int>("MyProperty")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkReportId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("WorkReportId");

                    b.ToTable("WorkUnits");
                });

            modelBuilder.Entity("BlazorTimeCalculator.Model.WorkUnit", b =>
                {
                    b.HasOne("BlazorTimeCalculator.Model.WorkReport", "WorkReport")
                        .WithMany("WorkUnits")
                        .HasForeignKey("WorkReportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkReport");
                });

            modelBuilder.Entity("BlazorTimeCalculator.Model.WorkReport", b =>
                {
                    b.Navigation("WorkUnits");
                });
#pragma warning restore 612, 618
        }
    }
}
