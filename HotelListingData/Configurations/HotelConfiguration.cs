using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListingData.Configurations {
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel> {
        public void Configure(EntityTypeBuilder<Hotel> builder) {
            builder.HasData(
                    new Hotel {
                        Id = 1,
                        Name = "Pardaras Hotel",
                        Address = "Tula",
                        Rating = 4.5,
                        CountryId = 1
                    },
                    new Hotel {
                        Id = 2,
                        Name = "Surf Hostekl",
                        Address = "Batumi",
                        Rating = 4.7,
                        CountryId = 2
                    },
                    new Hotel {
                        Id = 3,
                        Name = "Fabrika",
                        Address = "Tbilisi",
                        Rating = 4.5,
                        CountryId = 2
                    }
                );
        }
    }
}
