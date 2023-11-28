using AutoMapper;
using HotelListingCore.Contracts;
using HotelListingData;

namespace HotelListingCore.Repositories {
    public class HotelRepository : GenericRepository<Hotel>, IHotelsRepository {
        public HotelRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper) {

        }
    }
}
