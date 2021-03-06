﻿using Microsoft.EntityFrameworkCore;
using StarWarTestAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarWarTestAPI.DBContext
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options)
            : base(options)
        {  }
        public DbSet<FilmModel> films { get; set; }

        public DbSet<Films_CharacterModels> films_characters { get; set; }

        public DbSet<Films_Species> films_species { get; set; }

        public DbSet<People_Species> species_people { get; set; }
        public DbSet<PersonModel> people { get; set; }
        public DbSet<PlanetModel> planets { get; set; }
        public DbSet<SpeciesModel> species { get; set; }
        public DbSet<StarshipModel> starships { get; set; }
        public DbSet<TransportModel> transports { get; set; }
        public DbSet<VehicleModel> vehicles { get; set; }

        public DbSet<Films_StarShips> films_starships { get; set; }
        public DbSet<StarsShips_Pilot> starships_pilots { get; set; }

        public DbSet<Films_Planet> films_planets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Films_CharacterModels>()
                .HasKey(c => new { c.people_id, c.film_id });

            modelBuilder.Entity<Films_Species>()
                .HasKey(c => new { c.species_id, c.film_id });

            modelBuilder.Entity<People_Species>()
                .HasKey(c => new { c.species_id, c.people_id });

            modelBuilder.Entity<Films_StarShips>()
               .HasKey(c => new { c.starship_id, c.film_id });

            modelBuilder.Entity<StarsShips_Pilot>()
               .HasKey(c => new { c.starship_id, c.people_id });

            modelBuilder.Entity<Films_Planet>()
               .HasKey(c => new { c.film_id, c.planet_id });
        }
    }
}
