namespace FitnessManager.Models
{
    public class Trainer : User
    {
        public int Id { get; set; }

        public int Age { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public virtual List<Course> Courses { get; set; } = new List<Course>();

        public List<TrainerEnrollment> TrainerEnrollments { get; set; } = new List<TrainerEnrollment>();
    }
}
