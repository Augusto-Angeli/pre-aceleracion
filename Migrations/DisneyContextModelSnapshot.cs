﻿// <auto-generated />
using System;
using Aceleracion.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aceleracion.Migrations
{
    [DbContext(typeof(DisneyContext))]
    partial class DisneyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("disney")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Aceleracion.Entities.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("History")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            CharacterId = 5,
                            Age = 20,
                            History = "A toy",
                            Image = "Buzz Image",
                            Name = "Buzz",
                            Weight = 3
                        },
                        new
                        {
                            CharacterId = 6,
                            Age = 25,
                            History = "A Mouse",
                            Image = "Mickey Image",
                            Name = "Mickey",
                            Weight = 4
                        });
                });

            modelBuilder.Entity("Aceleracion.Entities.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            GenreId = 1,
                            Image = "Action Image",
                            Name = "Action"
                        },
                        new
                        {
                            GenreId = 2,
                            Image = "Comedy Image",
                            Name = "Comedy"
                        },
                        new
                        {
                            GenreId = 3,
                            Image = "Suspense Image",
                            Name = "Suspense"
                        },
                        new
                        {
                            GenreId = 4,
                            Image = "Drama Image",
                            Name = "Drama"
                        },
                        new
                        {
                            GenreId = 5,
                            Image = "Romance Image",
                            Name = "Romance"
                        });
                });

            modelBuilder.Entity("Aceleracion.Entities.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Qualification")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MovieId");

                    b.HasIndex("GenreId");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            MovieId = 5,
                            CreationDate = new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            GenreId = 5,
                            Image = "The Lion King Image",
                            Qualification = 2,
                            Title = "The Lion King"
                        },
                        new
                        {
                            MovieId = 6,
                            CreationDate = new DateTime(2021, 7, 15, 0, 0, 0, 0, DateTimeKind.Local),
                            GenreId = 5,
                            Image = "Cars Image",
                            Qualification = 5,
                            Title = "Cars"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersCharacterId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesMovieId")
                        .HasColumnType("int");

                    b.HasKey("CharactersCharacterId", "MoviesMovieId");

                    b.HasIndex("MoviesMovieId");

                    b.ToTable("CharacterMovie");
                });

            modelBuilder.Entity("Aceleracion.Entities.Movie", b =>
                {
                    b.HasOne("Aceleracion.Entities.Genre", "Genres")
                        .WithMany("Movies")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("Aceleracion.Entities.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersCharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aceleracion.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Aceleracion.Entities.Genre", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
