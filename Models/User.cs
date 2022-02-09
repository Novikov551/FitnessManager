using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessManager.Models
{
    public interface User
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("age")]
        public int Age { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("surname")]
        public string SurName { get; set; }

        public List<Course> Courses { get; set; }
    }
}
