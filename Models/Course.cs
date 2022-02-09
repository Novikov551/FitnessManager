using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessManager.Models
{
    public class Course
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("number_of_hourses")]
        public int NumberOfHourses { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        [StringLength(2000, MinimumLength = 0)]
        public string Description { get; set; }
         
        public virtual List<Student> Students { get; set; } = new List<Student>();

        public virtual List<Trainer> Trainers { get; set; } = new List<Trainer>();

        public List<StudentEnrolment> StudentEnrollments { get; set; } = new List<StudentEnrolment>();

        public List<TrainerEnrollment> TrainersEnrollments { get; set; } = new List<TrainerEnrollment>();
    }
}
