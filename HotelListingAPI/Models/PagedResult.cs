namespace HotelListingAPI.Models {
    public class PagedResult<T> {
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int RecordIndex { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
