namespace e_commerceApp.Shared.Models.Auth
{
    public class ApiResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public T? ResponseRequest { get; set; }
    }
}
