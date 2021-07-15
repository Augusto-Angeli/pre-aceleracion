using Aceleracion.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Aceleracion.Contexts
{
    public class DisneyContext : DbContext
    {
        private const string Schema = "disney";
        public DisneyContext(DbContextOptions<DisneyContext> options) : base(options)
        {
        }       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<Genre>().HasData(new Genre
                {
                    GenreId = 1,
                    Name = "Action",
                    Image = "Action Image"                   
                },
                new Genre
                {
                    GenreId = 2,
                    Name = "Comedy",
                    Image = "Comedy Image"
                },
                new Genre
                {
                    GenreId = 3,
                    Name = "Suspense",
                    Image = "Suspense Image"
                },
                new Genre
                {
                    GenreId = 4,
                    Name = "Drama",
                    Image = "Drama Image"
                },
                 new Genre
                 {
                     GenreId = 5,
                     Name = "Romance",
                     Image = "Romance Image"
                 });


            modelBuilder.Entity<Character>().HasData(new Character
                {
                    CharacterId = 5,
                    Image = "Buzz Image",
                    Name = "Buzz",
                    Age = 20,
                    Weight = 3,
                    History = "A toy"
                },
                new Character
                {
                CharacterId = 6,
                    Image = "Mickey Image",
                    Name = "Mickey",
                    Age = 25,
                    Weight = 4,
                    History = "A Mouse"
                } 
                );

            modelBuilder.Entity<Movie>().HasData(new Movie
                {
                    MovieId = 5,
                    Image = "The Lion King Image",
                    Title = "The Lion King",
                    CreationDate = DateTime.Today.Date,
                    Qualification = 2,
                    GenreId = 5
            },

                 new Movie
                 {
                     MovieId = 6,
                     Image = "Cars Image",
                     Title = "Cars",
                     CreationDate = DateTime.Today.Date,
                     Qualification = 5,
                     GenreId = 5
                 }
                );
        }

        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;

    }
}
