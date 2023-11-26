using AutoMapper;
using HotelListingAPI.Contracts;
using HotelListingAPI.Data;

namespace HotelListingAPI.Repositories {
    public class HotelRepository : GenericRepository<Hotel>, IHotelsRepository {
        public HotelRepository(HotelListingDbContext context, IMapper mapper) : base(context, mapper) {
            
        }
    }
}
