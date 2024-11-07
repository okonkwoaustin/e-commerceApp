namespace e_commerceApp.Shared
{
    public record ServiceResponse<T>(T Data, bool success = false, string message = null!);   
}
