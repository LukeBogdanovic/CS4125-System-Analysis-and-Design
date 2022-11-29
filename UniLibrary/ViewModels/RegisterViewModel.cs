namespace UniLibrary.ViewModels
{

    public class RegisterViewModel
    {
        [Required]
        public string? StudentID { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.Password), Required]
        public string? Password { get; set; }
        [DataType(DataType.Password), Compare("Password"), Required]
        public string? ConfirmPassword { get; set; }
        [Required]
        public string? UserType { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        public string? StudentID { get; set; }
        [DataType(DataType.Password), Required]
        public string? Password { get; set; }
    }

}