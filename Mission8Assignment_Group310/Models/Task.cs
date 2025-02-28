using System.ComponentModel.DataAnnotations;
using Mission8Assignment_Group310.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission8Assignment_Group310.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName {  get; set; }

        public string? DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }

        public bool? Complete { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}


