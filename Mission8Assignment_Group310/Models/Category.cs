using System.ComponentModel.DataAnnotations;

namespace Mission8Assignment_Group310.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        public string? CategoryName { get; set; }


        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}
