﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sudoku.Data;

#nullable disable

namespace Sudoku.Migrations
{
    [DbContext(typeof(SudokuContext))]
    partial class SudokuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sudoku.Models.SudokuModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrentBoard")
                        .HasMaxLength(161)
                        .HasColumnType("nvarchar(161)");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Help")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalBoard")
                        .IsRequired()
                        .HasMaxLength(161)
                        .HasColumnType("nvarchar(161)");

                    b.Property<bool>("Solved")
                        .HasColumnType("bit");

                    b.Property<string>("SolvedBoard")
                        .HasMaxLength(161)
                        .HasColumnType("nvarchar(161)");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SudokuModel");
                });
#pragma warning restore 612, 618
        }
    }
}
