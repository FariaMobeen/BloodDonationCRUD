﻿// <auto-generated />
using BloodDonation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BloodDonation.Migrations
{
    [DbContext(typeof(DonationDBContext))]
    partial class DonationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.1");

            modelBuilder.Entity("BloodDonation.Models.DCandidate", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("bloodGroup")
                        .IsRequired()
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("id");

                    b.ToTable("DCandidates");
                });
#pragma warning restore 612, 618
        }
    }
}
