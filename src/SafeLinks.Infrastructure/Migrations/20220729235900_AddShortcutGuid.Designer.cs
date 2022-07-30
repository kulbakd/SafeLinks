﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SafeLinks.Infrastructure.Contexts;

#nullable disable

namespace SafeLinks.Infrastructure.Migrations
{
    [DbContext(typeof(SafeLinksDbContext))]
    [Migration("20220729235900_AddShortcutGuid")]
    partial class AddShortcutGuid
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("SafeLinks.Core.Domain.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SafetyAnalysisId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SafetyAnalysisId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("SafeLinks.Core.Domain.Entities.SafetyAnalysis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("SafetyAnalyses");
                });

            modelBuilder.Entity("SafeLinks.Core.Domain.Entities.Shortcut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("LinkId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ShortGuid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("Shortcuts");
                });

            modelBuilder.Entity("SafeLinks.Core.Domain.Entities.Link", b =>
                {
                    b.HasOne("SafeLinks.Core.Domain.Entities.SafetyAnalysis", "SafetyAnalysis")
                        .WithMany()
                        .HasForeignKey("SafetyAnalysisId");

                    b.Navigation("SafetyAnalysis");
                });

            modelBuilder.Entity("SafeLinks.Core.Domain.Entities.Shortcut", b =>
                {
                    b.HasOne("SafeLinks.Core.Domain.Entities.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");
                });
#pragma warning restore 612, 618
        }
    }
}
