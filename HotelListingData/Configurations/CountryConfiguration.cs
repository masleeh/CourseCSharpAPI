using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelListingAPI.Data.Configurations {
    public class CountryConfiguration : IEntityTypeConfiguration<Country> {
        public void Configure(EntityTypeBuilder<Country> builder) {
            builder.HasData(
                    new Country {
                        Id = 1,
                        Name = "Russia",
                        ShortName = "RUS"
                    },
                    new Country {
                        Id = 2,
                        Name = "Georgia",
                        ShortName = "GE"
                    },
                    new Country {
                        Id = 3,
                        Name = "Turkey",
                        ShortName = "TUR"
                    }
                );
        }
    }
}
