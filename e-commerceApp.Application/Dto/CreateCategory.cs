namespace e_commerceApp.Application.Dto
{
    public class CreateCategory
    {
        public string Name { get; set; }
    }

    public class UpdateCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
