﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReferralAPI.Data;

#nullable disable

namespace ReferralAPI.Migrations
{
    [DbContext(typeof(ReferralAPIContext))]
    [Migration("20230525011749_mssql.local_migration_263")]
    partial class mssqllocal_migration_263
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("ReferralAPI.Model.DynamicReferral", b =>
                {
                    b.Property<int>("DynamicReferralId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReferralJson")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DynamicReferralId");

                    b.ToTable("DynamicReferral");
                });

            modelBuilder.Entity("ReferralAPI.Model.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("TEXT");

                    b.HasKey("PatientId");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("ReferralAPI.Model.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProviderId");

                    b.ToTable("Provider");
                });

            modelBuilder.Entity("ReferralAPI.Model.Referral", b =>
                {
                    b.Property<int>("ReferralId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PatientId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProviderId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReferralDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReferralReason")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SpecailtyId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ReferralId");

                    b.HasIndex("PatientId");

                    b.ToTable("Referral");
                });

            modelBuilder.Entity("ReferralAPI.Model.Specialty", b =>
                {
                    b.Property<int>("SpecialtyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("SpecialtyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("SpecialtyId");

                    b.ToTable("Specialty");
                });

            modelBuilder.Entity("ReferralAPI.Model.Referral", b =>
                {
                    b.HasOne("ReferralAPI.Model.Patient", null)
                        .WithMany("Referrals")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ReferralAPI.Model.Patient", b =>
                {
                    b.Navigation("Referrals");
                });
#pragma warning restore 612, 618
        }
    }
}
