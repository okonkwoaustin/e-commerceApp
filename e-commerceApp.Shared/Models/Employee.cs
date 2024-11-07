namespace e_commerceApp.Shared.Models
{
    public class Employee
    {
        

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
