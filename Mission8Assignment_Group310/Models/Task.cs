using System.ComponentModel.DataAnnotations;

namespace Mission8Assignment_Group310.Models
{
    public class Task
    {
        [Key]
        public int FormId { get; set; }
        [Required]
        public string TaskName {  get; set; }

        public string? DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }

        public string? Category { get; set; }

        public bool? Complete { get; set; }
    }
}
