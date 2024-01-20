using System.ComponentModel.DataAnnotations;

namespace MedicalJournalApp.Models
{
    public class Article
    {
        [Required] 
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required] 
        public string Text { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        public string Category { get; set; }
    }
}