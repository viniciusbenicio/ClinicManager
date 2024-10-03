﻿// <auto-generated />
using System;
using ClinicManager.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(ClinicManagerDBContext))]
    [Migration("20241003023825_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClinicManager.Core.Entities.Care", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int")
                        .HasColumnName("DoctorId");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime")
                        .HasColumnName("End");

                    b.Property<string>("Healthinsurance")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Healthinsurance");

                    b.Property<int>("PatientId")
                        .HasColumnType("int")
                        .HasColumnName("PatientId");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int")
                        .HasColumnName("ServiceId");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime")
                        .HasColumnName("Start");

                    b.Property<int>("TypeService")
                        .HasColumnType("int")
                        .HasColumnName("TypeService");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.HasIndex("ServiceId")
                        .IsUnique();

                    b.ToTable("Care", "dbo");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CRMRegistration")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("CRMRegistration");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Specialty");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Doctors", "dbo");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Patients", "dbo");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("RoleName");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", "dbo");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Description");

                    b.Property<int>("Duration")
                        .HasColumnType("int")
                        .HasColumnName("Duration");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasPrecision(19, 4)
                        .HasColumnType("decimal")
                        .HasColumnName("Price");

                    b.HasKey("Id");

                    b.ToTable("Services", "dbo");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Address");

                    b.Property<string>("Bloodtype")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar")
                        .HasColumnName("Bloodtype");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar")
                        .HasColumnName("Document");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("FirstName");

                    b.Property<string>("Height")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("Height");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("LastName");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("PasswordHash");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar")
                        .HasColumnName("Telephone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Username");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar")
                        .HasColumnName("Weight");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.Care", b =>
                {
                    b.HasOne("ClinicManager.Core.Entities.Doctor", "Doctor")
                        .WithOne()
                        .HasForeignKey("ClinicManager.Core.Entities.Care", "DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClinicManager.Core.Entities.Patient", "Patient")
                        .WithOne()
                        .HasForeignKey("ClinicManager.Core.Entities.Care", "PatientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClinicManager.Core.Entities.Service", "Service")
                        .WithOne()
                        .HasForeignKey("ClinicManager.Core.Entities.Care", "ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.Doctor", b =>
                {
                    b.HasOne("ClinicManager.Core.Entities.User", "User")
                        .WithOne("Doctor")
                        .HasForeignKey("ClinicManager.Core.Entities.Doctor", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.Patient", b =>
                {
                    b.HasOne("ClinicManager.Core.Entities.User", "User")
                        .WithOne("Patient")
                        .HasForeignKey("ClinicManager.Core.Entities.Patient", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.User", b =>
                {
                    b.HasOne("ClinicManager.Core.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ClinicManager.Core.Entities.User", b =>
                {
                    b.Navigation("Doctor")
                        .IsRequired();

                    b.Navigation("Patient")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
