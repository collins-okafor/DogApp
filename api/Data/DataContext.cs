using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options): base(options)
        
        {
        }

        public DbSet <Dog> Dogs { get; set; }
        public DbSet <Breed> Breeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var DogId = 1;
            var BreedId = 1;

            var dogSeeder = new Faker<Dog>()
                .RuleFor(d => d.DogId, f => DogId++)
                .RuleFor(d => d.Name, f => f.Name.Random.String(1,5))
                .RuleFor(d => d.Age, f => f.Random.Int(1,5))
                .RuleFor(d => d.Gender, f => f.Random.String(1,5))
                .RuleFor(d => d.color, f => f.Random.String(1,5))
                .RuleFor(d => d.FavoriteFood, f => f.Random.String(1,5))
                .RuleFor(d => d.FavoriteToy, f => f.Random.String(1,5));
                modelBuilder.Entity<Dog>().HasData(dogSeeder.GenerateBetween(10, 10));

            var breedSeeder = new Faker<Breed>()
                .RuleFor(br => br.BreedId, f => BreedId++)
                .RuleFor(br => br.Name, f => f.Random.String(1,5))
                .RuleFor(br => br.Size, f => f.Random.String(1, 4))
                .RuleFor(br => br.Friendliness, f => f.Random.Int(1, 5))
                .RuleFor(br => br.Trainability, f => f.Random.Int(1, 5))
                .RuleFor(br => br.SheddingAmount, f => f.Random.Int(1, 5))
                .RuleFor(br => br.ExerciseNeeds, f => f.Random.Int(1, 5));
            modelBuilder.Entity<Breed>().HasData(breedSeeder.GenerateBetween(10, 10));
        }

    }
}