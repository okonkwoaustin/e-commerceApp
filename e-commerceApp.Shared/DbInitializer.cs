using e_commerceApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerceApp.Shared
{
    public static class DbInitializer
    {
        public static void GenerateSeed(this ModelBuilder modelBuilder)
        {
            var employees = new[]
            {
                new Employee { Id = 1 , FullName ="MHSN27 MHSN", Department ="Sales", DateOfBirth = new DateTime(1974, 6, 10), Age = 49, PhoneNumber = "+1 1774867925" },
                new Employee { Id = 2 , FullName ="Sohel Shaikh", Department ="Product Management", DateOfBirth = new DateTime(1979, 2, 2), Age = 44, PhoneNumber = "+1 1280221170" },
                new Employee { Id = 3 , FullName ="Mark Johnnah", Department ="Public Relations (PR)", DateOfBirth = new DateTime(1980, 1, 22), Age = 43, PhoneNumber = "+1 6391420937" },
                new Employee { Id = 4 , FullName ="JB _", Department ="Quality Assurance (QA)", DateOfBirth = new DateTime(1968, 8, 19), Age = 55, PhoneNumber = "+1 1634119861" },
                new Employee { Id = 5 , FullName ="hugo sanchez", Department ="Logistics", DateOfBirth = new DateTime(1953, 6, 10), Age = 70, PhoneNumber = "+1 7644917715" },
                new Employee { Id = 6 , FullName ="Zabi Rahmani", Department ="Administration", DateOfBirth = new DateTime(1953, 9, 12), Age = 70, PhoneNumber = "+1 5082755411" },
                new Employee { Id = 7 , FullName ="edimar lopes", Department ="Training and Development", DateOfBirth = new DateTime(1963, 11, 21), Age = 60, PhoneNumber = "+1 5745426751" },
                new Employee { Id = 8 , FullName ="Arie melans", Department ="Research and Development (R&D)", DateOfBirth = new DateTime(1980, 12, 7), Age = 43, PhoneNumber = "+1 5367480161" },
                new Employee { Id = 9 , FullName ="Ziya Çetinkaya", Department ="Product Management", DateOfBirth = new DateTime(1970, 8, 6), Age = 53, PhoneNumber = "+1 2379992102" },
                new Employee { Id = 10 , FullName ="Thiago Paiva Medeiros", Department ="Public Relations (PR)", DateOfBirth = new DateTime(2005, 7, 11), Age = 18, PhoneNumber = "+1 2495860935" },
                new Employee { Id = 11 , FullName ="Thanh Nguyen", Department ="Facilities Management", DateOfBirth = new DateTime(1967, 2, 25), Age = 56, PhoneNumber = "+1 3911316611" },
                new Employee { Id = 12 , FullName ="Rahul Salokhe", Department ="Sales", DateOfBirth = new DateTime(1984, 5, 23), Age = 39, PhoneNumber = "+1 5182461859" },
                new Employee { Id = 13 , FullName ="Jing Tarng Loke", Department ="Operations", DateOfBirth = new DateTime(2000, 7, 13), Age = 23, PhoneNumber = "+1 2635917946" },
                new Employee { Id = 14 , FullName ="met it", Department ="Human Resources (HR)", DateOfBirth = new DateTime(1987, 10, 19), Age = 36, PhoneNumber = "+1 5049298944" },
                new Employee { Id = 15 , FullName ="Md.Ariful Islam", Department ="Research and Development (R&D)", DateOfBirth = new DateTime(1973, 11, 29), Age = 50, PhoneNumber = "+1 9252292089" },
                new Employee { Id = 16 , FullName ="Mo Canada", Department ="Legal", DateOfBirth = new DateTime(1976, 7, 12), Age = 47, PhoneNumber = "+1 1824118974" },
                new Employee { Id = 17 , FullName ="Altanzurkh T", Department ="Administration", DateOfBirth = new DateTime(1997, 5, 12), Age = 26, PhoneNumber = "+1 6395646874" },
                new Employee { Id = 18 , FullName ="Mustafa YILDIZ", Department ="Public Relations (PR)", DateOfBirth = new DateTime(1951, 12, 3), Age = 72, PhoneNumber = "+1 1375269492" },
                new Employee { Id = 19 , FullName ="Arief Fauzi", Department ="Quality Assurance (QA)", DateOfBirth = new DateTime(1959, 3, 13), Age = 64, PhoneNumber = "+1 3458476129" },
                new Employee { Id = 20 , FullName ="salvador castillo", Department ="Engineering", DateOfBirth = new DateTime(1951, 7, 21), Age = 72, PhoneNumber = "+1 4486306495" },
                new Employee { Id = 21 , FullName ="Luis TC", Department ="Training and Development", DateOfBirth = new DateTime(1961, 9, 30), Age = 62, PhoneNumber = "+1 1280221170" },
                new Employee { Id = 22 , FullName ="Adeel Baig", Department ="Finance", DateOfBirth = new DateTime(1991, 1, 14), Age = 32, PhoneNumber = "+1 6391420937" },
                new Employee { Id = 23 , FullName ="Novrita Inkac", Department ="Information Technology (IT)", DateOfBirth = new DateTime(1971, 12, 5), Age = 52, PhoneNumber = "+1 1634119861" },
                new Employee { Id = 24 , FullName ="Felipe Rodríguez", Department ="Data Analytics", DateOfBirth = new DateTime(1966, 4, 10), Age = 57, PhoneNumber = "+1 7644917715" },
                new Employee { Id = 25 , FullName ="Fabian Cebreros", Department ="Legal", DateOfBirth = new DateTime(1993, 8, 5), Age = 30, PhoneNumber = "+1 5082755411" },
                new Employee { Id = 26 , FullName ="Alan Michas", Department ="Customer Support", DateOfBirth = new DateTime(1970, 11, 13), Age = 53, PhoneNumber = "+1 5745426751" },
                new Employee { Id = 27 , FullName ="Lucky D.Bog", Department ="Administration", DateOfBirth = new DateTime(1957, 4, 9), Age = 66, PhoneNumber = "+1 5367480161" },
                new Employee { Id = 28 , FullName ="Anunu", Department ="Research and Development (R&D)", DateOfBirth = new DateTime(1968, 9, 22), Age = 55, PhoneNumber = "+1 2379992102" },
                new Employee { Id = 29 , FullName ="KRAK 08", Department ="Product Management", DateOfBirth = new DateTime(1997, 6, 20), Age = 26, PhoneNumber = "+1 2495860935" },
                new Employee { Id = 30 , FullName ="Boonsit Chanpoempoonpol", Department ="Customer Support", DateOfBirth = new DateTime(1976, 3, 28), Age = 47, PhoneNumber = "+1 3911316611" },
                new Employee { Id = 31 , FullName ="Danilo Romao", Department ="Business Development", DateOfBirth = new DateTime(1979, 3, 17), Age = 44, PhoneNumber = "+1 5182461859" },
                new Employee { Id = 32 , FullName ="User 4571", Department ="Logistics", DateOfBirth = new DateTime(1999, 6, 2), Age = 24, PhoneNumber = "+1 2635917946" },
                new Employee { Id = 33 , FullName ="Yuri Svyrydov", Department ="Information Technology (IT)", DateOfBirth = new DateTime(1976, 6, 5), Age = 47, PhoneNumber = "+1 5049298944" },
                new Employee { Id = 34 , FullName ="Omar Abdelrahim", Department ="Procurement", DateOfBirth = new DateTime(1986, 11, 6), Age = 37, PhoneNumber = "+1 9252292089" },
                new Employee { Id = 35 , FullName ="ADIAN Jan", Department ="Quality Assurance (QA)", DateOfBirth = new DateTime(1993, 7, 10), Age = 30, PhoneNumber = "+1 1824118974" },
                new Employee { Id = 36 , FullName ="Thiago Valim", Department ="Finance", DateOfBirth = new DateTime(2003, 5, 28), Age = 20, PhoneNumber = "+1 6395646874" },
                new Employee { Id = 37 , FullName ="ศุภชัย สมพานิช", Department ="Facilities Management", DateOfBirth = new DateTime(1980, 4, 15), Age = 43, PhoneNumber = "+1 1375269492" },
                new Employee { Id = 38 , FullName ="ArTWorK211", Department ="Customer Support", DateOfBirth = new DateTime(1975, 2, 21), Age = 48, PhoneNumber = "+1 3458476129" },
                new Employee { Id = 39 , FullName ="Johny Angsana", Department ="Information Technology (IT)", DateOfBirth = new DateTime(1954, 9, 27), Age = 69, PhoneNumber = "+1 4486306495" },
                new Employee { Id = 40 , FullName ="kommineni narendra", Department ="Administration", DateOfBirth = new DateTime(1957, 9, 9), Age = 66, PhoneNumber = "+1 1774867925" },
                new Employee { Id = 41 , FullName ="Felipe Ramos", Department ="Procurement", DateOfBirth = new DateTime(1971, 3, 14), Age = 52, PhoneNumber = "+1 1280221170" },
                new Employee { Id = 42 , FullName ="Maroine Chérif", Department ="Operations", DateOfBirth = new DateTime(1998, 2, 3), Age = 25, PhoneNumber = "+1 6391420937" },
                new Employee { Id = 43 , FullName ="Sana Ullah", Department ="Engineering", DateOfBirth = new DateTime(1986, 10, 28), Age = 37, PhoneNumber = "+1 1634119861" },
                new Employee { Id = 44 , FullName ="michel akebo", Department ="Public Relations (PR)", DateOfBirth = new DateTime(1973, 4, 4), Age = 50, PhoneNumber = "+1 7644917715" },
                new Employee { Id = 45 , FullName ="عمر العمودي Omar Al-Amoudi", Department ="Logistics", DateOfBirth = new DateTime(1981, 2, 25), Age = 42, PhoneNumber = "+1 5082755411" },
                new Employee { Id = 46 , FullName ="Louay Abdel Maeen", Department ="Business Development", DateOfBirth = new DateTime(2003, 12, 24), Age = 20, PhoneNumber = "+1 5745426751" },
                new Employee { Id = 47 , FullName ="Black-Gold Sarnaut", Department ="Marketing", DateOfBirth = new DateTime(1967, 9, 9), Age = 56, PhoneNumber = "+1 5367480161" },
                new Employee { Id = 48 , FullName ="gueye abdoulaye", Department ="Finance", DateOfBirth = new DateTime(1968, 3, 19), Age = 55, PhoneNumber = "+1 2379992102" },
                new Employee { Id = 49 , FullName ="Cristian Ferreira", Department ="Engineering", DateOfBirth = new DateTime(1989, 1, 24), Age = 34, PhoneNumber = "+1 2495860935" },
                new Employee { Id = 50 , FullName ="Amir Osama", Department ="Finance", DateOfBirth = new DateTime(1972, 5, 2), Age = 51, PhoneNumber = "+1 3911316611" },
                new Employee { Id = 51 , FullName ="Mihai Moisei", Department ="Human Resources (HR)", DateOfBirth = new DateTime(1965, 5, 29), Age = 58, PhoneNumber = "+1 5182461859" },
                new Employee { Id = 52 , FullName ="AKHOM ALY", Department ="Procurement", DateOfBirth = new DateTime(2005, 3, 27), Age = 18, PhoneNumber = "+1 2635917946" },
                new Employee { Id = 53 , FullName ="Banpote Jaruboon", Department ="Customer Support", DateOfBirth = new DateTime(1971, 10, 26), Age = 52, PhoneNumber = "+1 5049298944" },
                new Employee { Id = 54 , FullName ="Abdul Razak Abdulai", Department ="Sales", DateOfBirth = new DateTime(1962, 3, 24), Age = 61, PhoneNumber = "+1 9252292089" },
                new Employee { Id = 55 , FullName ="ELy moussa", Department ="Product Management", DateOfBirth = new DateTime(2001, 8, 17), Age = 22, PhoneNumber = "+1 1824118974" },
                new Employee { Id = 56 , FullName ="peter tharwat", Department ="Facilities Management", DateOfBirth = new DateTime(1983, 7, 9), Age = 40, PhoneNumber = "+1 6395646874" },
                new Employee { Id = 57 , FullName ="william programer (CLASH OF CLAN)", Department ="Finance", DateOfBirth = new DateTime(1985, 10, 29), Age = 38, PhoneNumber = "+1 1375269492" },
                new Employee { Id = 58 , FullName ="Luis Correa", Department ="Sales", DateOfBirth = new DateTime(1969, 1, 24), Age = 54, PhoneNumber = "+1 3458476129" },
                new Employee { Id = 59 , FullName ="Michael Chizoba", Department ="Product Management", DateOfBirth = new DateTime(1965, 9, 17), Age = 58, PhoneNumber = "+1 4486306495" },
                new Employee { Id = 60 , FullName ="Abdul-Rouf Ammar", Department ="Quality Assurance (QA)", DateOfBirth = new DateTime(2005, 2, 22), Age = 18, PhoneNumber = "+1 1280221170" },
                new Employee { Id = 61 , FullName ="Norbert Saint Georges", Department ="Marketing", DateOfBirth = new DateTime(2000, 7, 12), Age = 23, PhoneNumber = "+1 6391420937" },
                new Employee { Id = 62 , FullName ="trieuvnh", Department ="Research and Development (R&D)", DateOfBirth = new DateTime(2004, 12, 17), Age = 19, PhoneNumber = "+1 1634119861" },
                new Employee { Id = 63 , FullName ="Amr Moh", Department ="Procurement", DateOfBirth = new DateTime(1963, 9, 2), Age = 60, PhoneNumber = "+1 7644917715" },
                new Employee { Id = 64 , FullName ="Ton", Department ="Information Technology (IT)", DateOfBirth = new DateTime(2003, 4, 12), Age = 20, PhoneNumber = "+1 5082755411" },
                new Employee { Id = 65 , FullName ="Prathamesh Karande", Department ="Quality Assurance (QA)", DateOfBirth = new DateTime(1957, 12, 23), Age = 66, PhoneNumber = "+1 5745426751" },
                new Employee { Id = 66 , FullName ="MarianoT3", Department ="Human Resources (HR)", DateOfBirth = new DateTime(1950, 12, 26), Age = 73, PhoneNumber = "+1 5367480161" },
                new Employee { Id = 67 , FullName ="Rekzon Aborde", Department ="Human Resources (HR)", DateOfBirth = new DateTime(1989, 1, 27), Age = 34, PhoneNumber = "+1 2379992102" },
                new Employee { Id = 68 , FullName ="prottoy roy", Department ="Information Technology (IT)", DateOfBirth = new DateTime(1980, 12, 14), Age = 43, PhoneNumber = "+1 2495860935" },
                new Employee { Id = 69 , FullName ="sahli SAHBI", Department ="Product Management", DateOfBirth = new DateTime(2001, 5, 22), Age = 22, PhoneNumber = "+1 3911316611" },
                new Employee { Id = 70 , FullName ="Onur Hos", Department ="Administration", DateOfBirth = new DateTime(1977, 7, 7), Age = 46, PhoneNumber = "+1 5182461859" },
                new Employee { Id = 71 , FullName ="Armando Villagomez", Department ="Data Analytics", DateOfBirth = new DateTime(1978, 7, 4), Age = 45, PhoneNumber = "+1 2635917946" },
                new Employee { Id = 72 , FullName ="Jesus Alberto Roque Ortiz", Department ="Facilities Management", DateOfBirth = new DateTime(1988, 8, 9), Age = 35, PhoneNumber = "+1 5049298944" },
                new Employee { Id = 73 , FullName ="Md Shahin Aktar", Department ="Facilities Management", DateOfBirth = new DateTime(1964, 5, 19), Age = 59, PhoneNumber = "+1 9252292089" },
                new Employee { Id = 74 , FullName ="Антон Метелёв", Department ="Customer Support", DateOfBirth = new DateTime(1958, 1, 24), Age = 65, PhoneNumber = "+1 1824118974" },
            };

            // Add the tickets to the model
            foreach (var employee in employees)
            {
                modelBuilder.Entity<Employee>().HasData(employee);
            }
        }
    }
}
