using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessManager.Models
{
    public class Student
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public virtual List<Course> Courses { get; set; } = new List<Course>();

        public List<StudentEnrolment> StudentEnrollments { get; set; } = new List<StudentEnrolment>();
    }
}
