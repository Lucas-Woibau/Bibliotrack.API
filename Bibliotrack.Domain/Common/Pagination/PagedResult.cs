namespace Bibliotrack.Domain.Common.Pagination
{
    public class PagedResult<T>
    {
        public PagedResult(List<T> items, int pageNumber, int pageSize, int totalRecords)
        {
            Items = items;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
        }

        public List<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }

        public int TotalPages => (int)Math.Ceiling(TotalRecords / (double)PageSize);

        public bool HasPreviusPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPages;
    }
}
