using Microsoft.EntityFrameworkCore;

namespace HotelListingAPI.Data {
    public class HotelListingDbContext : DbContext {
        public HotelListingDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(
                    new Country {
                        Id = 1, Name = "Russia", ShortName = "RUS"
                    },
                    new Country {
                        Id = 2, Name = "Georgia", ShortName = "GE"
                    },
                    new Country {
                        Id = 3, Name = "Turkey", ShortName = "TUR"
                    }
                );

            modelBuilder.Entity<Hotel>().HasData(
                    new Hotel {
                        Id = 1, Name = "Pardaras Hotel", Address = "Tula", Rating = 4.5, CountryId = 1
                    },
                    new Hotel {
                        Id = 2, Name = "Surf Hostekl", Address = "Batumi", Rating = 4.7, CountryId = 2
                    },
                    new Hotel {
                        Id = 3, Name = "Fabrika", Address = "Tbilisi", Rating = 4.5, CountryId = 2
                    }
                );
        }
    }
}
