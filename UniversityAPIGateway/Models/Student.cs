using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityAPIGateway.Models
{
    [Table("Student")]
    public class Student
    {

        [Required(ErrorMessage ="StudentID is required")]
        public int studentID { get; set; }

        [StringLength(150)]
        public String Name { get; set; }

        public String Standing { get; set; }

        public double GPA { get; set; }

        public String Address { get; set; }

        public String Major { get; set; }

        public String BirthDate { get; set; }



    }
}
