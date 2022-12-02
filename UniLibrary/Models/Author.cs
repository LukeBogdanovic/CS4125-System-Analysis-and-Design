namespace UniLibrary.Models
{
    public class Author
    {
        public int ID { get; set; }
        [Display(Name = "Full Name")]
        [MaxLength(30)]
        [Required]
        public string Name { get; set; } = string.Empty;
        public IList<BookDetails>? Books { get; set; }
    }
}