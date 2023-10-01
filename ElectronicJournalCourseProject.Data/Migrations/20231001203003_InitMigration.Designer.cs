﻿// <auto-generated />
using System;
using ElectronicJournalCourseProject.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElectronicJournalCourseProject.Data.Migrations
{
    [DbContext(typeof(ElectronicJournalContext))]
    [Migration("20231001203003_InitMigration")]
    partial class InitMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DropOutDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<long>("StudentIdNumber")
                        .HasColumnType("bigint");

                    b.HasKey("AppointmentId");

                    b.HasIndex("StudentIdNumber");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Group", b =>
                {
                    b.Property<int>("GroupCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GroupCode"));

                    b.Property<int>("Abbreviature")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyCode")
                        .HasColumnType("int");

                    b.HasKey("GroupCode");

                    b.HasIndex("SpecialtyCode");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonId"));

                    b.Property<DateTime>("LessonDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LoadListId")
                        .HasColumnType("int");

                    b.HasKey("LessonId");

                    b.HasIndex("LoadListId");

                    b.ToTable("Lessons");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.LoadList", b =>
                {
                    b.Property<int>("LoadListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoadListId"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("PlanId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("LoadListId");

                    b.HasIndex("GroupId");

                    b.HasIndex("PlanId");

                    b.HasIndex("TeacherId");

                    b.ToTable("LoadLists");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Mark", b =>
                {
                    b.Property<int>("MarkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MarkId"));

                    b.Property<bool>("Attendance")
                        .HasColumnType("bit");

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<int>("MarkValue")
                        .HasColumnType("int");

                    b.Property<long>("StudentIdNumber")
                        .HasColumnType("bigint");

                    b.HasKey("MarkId");

                    b.HasIndex("LessonId");

                    b.HasIndex("StudentIdNumber");

                    b.ToTable("Marks");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Plan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlanId"));

                    b.Property<int>("AcademicYear")
                        .HasColumnType("int");

                    b.Property<int>("HoursCount")
                        .HasColumnType("int");

                    b.Property<int>("SemesterNumber")
                        .HasColumnType("int");

                    b.Property<int>("SpecialtyCode")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("PlanId");

                    b.HasIndex("SpecialtyCode");

                    b.HasIndex("SubjectId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Specialty", b =>
                {
                    b.Property<int>("SpecialtyCode")
                        .HasColumnType("int");

                    b.Property<string>("SpecialtyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SpecialtyCode");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Student", b =>
                {
                    b.Property<long>("StudentIdNumber")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CurrentGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentPatronymic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentIdNumber");

                    b.HasIndex("CurrentGroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Teacher", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeacherId"));

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeacherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherPatronymic")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TeacherSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeacherId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Appointment", b =>
                {
                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Student", "Student")
                        .WithMany("Appointment")
                        .HasForeignKey("StudentIdNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Group", b =>
                {
                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Specialty", "Specialty")
                        .WithMany("Group")
                        .HasForeignKey("SpecialtyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Lesson", b =>
                {
                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.LoadList", "LoadList")
                        .WithMany("Lesson")
                        .HasForeignKey("LoadListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoadList");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.LoadList", b =>
                {
                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Group", "Group")
                        .WithMany("LoadList")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Plan", "Plan")
                        .WithMany("LoadList")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Plan");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Mark", b =>
                {
                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Lesson", "Lesson")
                        .WithMany("Mark")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Student", "Student")
                        .WithMany("Mark")
                        .HasForeignKey("StudentIdNumber")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Plan", b =>
                {
                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Specialty", "Specialty")
                        .WithMany("Plan")
                        .HasForeignKey("SpecialtyCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Subject", "Subject")
                        .WithMany("Plan")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Student", b =>
                {
                    b.HasOne("ElectronicJournalCourseProject.Data.Entities.Group", "Group")
                        .WithMany("Student")
                        .HasForeignKey("CurrentGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Group", b =>
                {
                    b.Navigation("LoadList");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Lesson", b =>
                {
                    b.Navigation("Mark");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.LoadList", b =>
                {
                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Plan", b =>
                {
                    b.Navigation("LoadList");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Specialty", b =>
                {
                    b.Navigation("Group");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Student", b =>
                {
                    b.Navigation("Appointment");

                    b.Navigation("Mark");
                });

            modelBuilder.Entity("ElectronicJournalCourseProject.Data.Entities.Subject", b =>
                {
                    b.Navigation("Plan");
                });
#pragma warning restore 612, 618
        }
    }
}
