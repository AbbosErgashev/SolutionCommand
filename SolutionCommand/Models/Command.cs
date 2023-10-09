using System.ComponentModel.DataAnnotations;

namespace Solution.Models
{
    public class Command
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        [MaxLength(250)]
        public string Platform { get; set; }

        [Required]
        public string CommandLine { get; set; }
    }
}