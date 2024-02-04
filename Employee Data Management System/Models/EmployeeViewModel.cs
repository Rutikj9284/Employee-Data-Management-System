using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee_Data_Management_System.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Date Of Birth")]
        public DateTime DOB { get; set; }

        [DisplayName("Experience(in years)")]
        public int Experience { get; set; }


        [DisplayName("Salary")]
        public double Salary { get; set; }

        [DisplayName("Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
