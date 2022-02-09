namespace FitnessManager.Models
{
    public class TrainerEnrollment
    {
        public int TrainerId { get; set; }

        public Trainer Trainer { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
