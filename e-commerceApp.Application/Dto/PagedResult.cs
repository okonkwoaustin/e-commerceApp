namespace e_commerceApp.Application.Dto
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; } 
        public int PageSize { get; set; } = 10;
        public int PageNumber { get; set; }
        public List<T> Items { get; set; } 
    }
}
