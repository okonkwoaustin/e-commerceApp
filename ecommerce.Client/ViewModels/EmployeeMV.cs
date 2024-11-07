namespace ecommerce.Client.ViewModels
{
    public class EmployeeMV
    {
        public int Id { get; set; }
        public string EmployeeIdView
        {
            get
            {
                return "EMP" + Id.ToString().PadLeft(4, '0');
            }
        }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public int Age { get; set; }
    }
}
