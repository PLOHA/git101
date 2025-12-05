using System.ComponentModel;

namespace EmployeeManagement.Models
{
    public class Employee : UserActivity
    {
        public int Id { get; set; }

        [DisplayName("รหัสพนักงาน")]
        public string EmpNo { get; set; }

        [DisplayName("ชื่อ")]
        public string FirstName { get; set; }

        [DisplayName("นามสกุล")]
        public string LastName { get; set; }

        [DisplayName("ชื่อ-นามสกุล")]
        public string FullName => $"{FirstName} {LastName}";

        [DisplayName("เบอร์ติดต่อ")]
        public int PhoneNumber { get; set; }

        [DisplayName("Email")]
        public string EmailAddress { get; set; }

        [DisplayName("ประเทศ")]
        public string Country { get; set; }

        [DisplayName("วันเกิด")]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("ที่อยู่")]
        public string Address { get; set; }

        [DisplayName("แผนก")]
        public string Department { get; set; }

        [DisplayName("ตำแหน่ง")]
        public string Designation { get; set; }
    }
}
