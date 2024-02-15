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
    [Migration("20240121105626_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "8.0.0");

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
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("parameters");

                    b.Property<string>("Playground")
                        .HasColumnType("TEXT")
                        .HasColumnName("playground");

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

            modelBuilder.Entity("ElgamalSandbox.Core.Entities.TaskDescription", b =>
                {
                    b.Navigation("Attempts");
                });
#pragma warning restore 612, 618
        }
    }
}