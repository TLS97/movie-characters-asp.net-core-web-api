﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieCharactersAPI.Models;

#nullable disable

namespace MovieCharactersAPI.Migrations
{
    [DbContext(typeof(MovieCharactersDbContext))]
    [Migration("20230228175837_SeedLinkingTable")]
    partial class SeedLinkingTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieCharactersAPI.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Alias = "alias",
                            Gender = "F",
                            Name = "Character1",
                            Picture = "picture url"
                        },
                        new
                        {
                            Id = 2,
                            Alias = "alias",
                            Gender = "F",
                            Name = "Character2",
                            Picture = "picture url"
                        },
                        new
                        {
                            Id = 3,
                            Alias = "alias",
                            Gender = "F",
                            Name = "Character3",
                            Picture = "picture url"
                        },
                        new
                        {
                            Id = 4,
                            Alias = "alias",
                            Gender = "F",
                            Name = "Character4",
                            Picture = "picture url"
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "blabla",
                            Name = "Franchise1"
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Director = "director",
                            FranchiseId = 1,
                            Genre = "genre",
                            Picture = "picture url",
                            ReleaseYear = 3000,
                            Title = "Movie1",
                            Trailer = "trailer url"
                        },
                        new
                        {
                            Id = 2,
                            Director = "director",
                            FranchiseId = 1,
                            Genre = "genre",
                            Picture = "picture url",
                            ReleaseYear = 1990,
                            Title = "Movie2",
                            Trailer = "trailer url"
                        });
                });

            modelBuilder.Entity("Roles", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            CharacterId = 1,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 2,
                            MovieId = 1
                        },
                        new
                        {
                            CharacterId = 3,
                            MovieId = 2
                        },
                        new
                        {
                            CharacterId = 4,
                            MovieId = 2
                        });
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Movie", b =>
                {
                    b.HasOne("MovieCharactersAPI.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("Roles", b =>
                {
                    b.HasOne("MovieCharactersAPI.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieCharactersAPI.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MovieCharactersAPI.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}