using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace UniLibrary.Models
{
    public class User
    {
        public int ID { get; set; }
        [MaxLength(8)]
        [Required]
        public string? StudentID { get; set; }
        [Display(Name = "Full Name")]
        [MaxLength]
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? EmailAddress { get; set; }

        public string? Password { get; set; }

        [ValidateNever]
        public IList<Loan>? Loans { get; set; }
    }
}