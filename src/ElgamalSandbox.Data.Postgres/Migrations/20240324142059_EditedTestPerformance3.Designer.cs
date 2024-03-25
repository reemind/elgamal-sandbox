﻿// <auto-generated />
using System;
using ElgamalSandbox.Data.SqLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ElgamalSandbox.Data.SqLite.Migrations
{
    [DbContext(typeof(EfContext))]
    [Migration("20240324142059_EditedTestPerformance3")]
    partial class EditedTestPerformance3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.PerformanceTest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время создания записи");

                    b.Property<string>("PrepareScript")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("prepare_script");

                    b.Property<long>("TaskDescriptionId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("task_description_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время изменения записи");

                    b.HasKey("Id")
                        .HasName("pk_performance_tests");

                    b.HasIndex("TaskDescriptionId")
                        .HasDatabaseName("ix_performance_tests_task_description_id");

                    b.ToTable("performance_tests", "public");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.PerformanceTestAttempt", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время создания записи");

                    b.Property<long>("PerformanceTestId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("performance_test_id");

                    b.Property<string>("Runs")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("runs");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время изменения записи");

                    b.HasKey("Id")
                        .HasName("pk_performance_test_attempt");

                    b.HasIndex("PerformanceTestId")
                        .HasDatabaseName("ix_performance_test_attempt_performance_test_id");

                    b.ToTable("performance_test_attempt", "public");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskAttempt", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время создания записи");

                    b.Property<bool>("IsSucceeded")
                        .HasColumnType("INTEGER")
                        .HasColumnName("is_succeeded");

                    b.Property<string>("Parameters")
                        .HasColumnType("TEXT")
                        .HasColumnName("parameters");

                    b.Property<string>("Playground")
                        .HasColumnType("TEXT")
                        .HasColumnName("playground");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("result");

                    b.Property<long>("TaskDescriptionId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("task_description_id");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время изменения записи");

                    b.HasKey("Id")
                        .HasName("pk_task_attempts");

                    b.HasIndex("TaskDescriptionId")
                        .HasDatabaseName("ix_task_attempts_task_description_id");

                    b.ToTable("task_attempts", "public");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskDescription", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время создания записи");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("InputVars")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("input_vars");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.Property<int>("Number")
                        .HasColumnType("INTEGER")
                        .HasColumnName("number");

                    b.Property<string>("OutputVars")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("output_vars");

                    b.Property<string>("Playground")
                        .HasColumnType("TEXT")
                        .HasColumnName("playground");

                    b.Property<string>("Toolbox")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("toolbox");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время изменения записи");

                    b.HasKey("Id")
                        .HasName("pk_task_descriptions");

                    b.ToTable("task_descriptions", "public");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskTest", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время создания записи");

                    b.Property<string>("InputVars")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("input_vars");

                    b.Property<string>("OutputVars")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("output_vars");

                    b.Property<long>("TaskId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("task_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()")
                        .HasComment("Время изменения записи");

                    b.HasKey("Id")
                        .HasName("pk_task_test");

                    b.HasIndex("TaskId")
                        .HasDatabaseName("ix_task_test_task_id");

                    b.ToTable("task_test", "public");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskTestAttemptRelation", b =>
                {
                    b.Property<long>("AttemptId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("attempt_id");

                    b.Property<long>("TestId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("test_id");

                    b.Property<int>("Result")
                        .HasColumnType("INTEGER")
                        .HasColumnName("result");

                    b.HasKey("AttemptId", "TestId")
                        .HasName("pk_task_test_attempt_relation");

                    b.HasIndex("TestId")
                        .HasDatabaseName("ix_task_test_attempt_relation_test_id");

                    b.ToTable("task_test_attempt_relation", "public");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.PerformanceTest", b =>
                {
                    b.HasOne("ElgamalSandbox.Core.Entities.TaskDescription", "TaskDescription")
                        .WithMany("PerformanceTests")
                        .HasForeignKey("TaskDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_performance_tests_task_descriptions_task_description_id");

                    b.Navigation("TaskDescription");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.PerformanceTestAttempt", b =>
                {
                    b.HasOne("ElgamalSandbox.Core.Entities.PerformanceTest", "PerformanceTest")
                        .WithMany("Attempts")
                        .HasForeignKey("PerformanceTestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_performance_test_attempt_performance_tests_performance_test_id");

                    b.Navigation("PerformanceTest");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskAttempt", b =>
                {
                    b.HasOne("ElgamalSandbox.Core.Entities.TaskDescription", "TaskDescription")
                        .WithMany("Attempts")
                        .HasForeignKey("TaskDescriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_attempts_task_descriptions_task_description_id");

                    b.Navigation("TaskDescription");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskTest", b =>
                {
                    b.HasOne("ElgamalSandbox.Core.Entities.TaskDescription", "Task")
                        .WithMany("Tests")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_test_task_descriptions_task_id");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskTestAttemptRelation", b =>
                {
                    b.HasOne("ElgamalSandbox.Core.Entities.TaskAttempt", "Attempt")
                        .WithMany("Tests")
                        .HasForeignKey("AttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_test_attempt_relation_task_attempts_attempt_id");

                    b.HasOne("ElgamalSandbox.Core.Entities.TaskTest", "Test")
                        .WithMany("Attempts")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_task_test_attempt_relation_task_test_test_id");

                    b.Navigation("Attempt");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.PerformanceTest", b =>
                {
                    b.Navigation("Attempts");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskAttempt", b =>
                {
                    b.Navigation("Tests");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskDescription", b =>
                {
                    b.Navigation("Attempts");

                    b.Navigation("PerformanceTests");

                    b.Navigation("Tests");
                });

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskTest", b =>
                {
                    b.Navigation("Attempts");
                });
#pragma warning restore 612, 618
        }
    }
}
