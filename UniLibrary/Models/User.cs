using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace UniLibrary.Models
{
    public class User
    {
        public int ID { get; set; }
        [MaxLength(8), Required]
        public string? StudentID { get; set; }
        [Display(Name = "Full Name"), Required, MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        [DataType(DataType.Password), Required]
        public string? Password { get; set; }
        [ValidateNever]
        public IList<Loan>? Loans { get; set; }
    }
}