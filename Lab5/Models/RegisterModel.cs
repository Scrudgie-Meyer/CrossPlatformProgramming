using System.ComponentModel.DataAnnotations;

namespace Lab5.Models;

public class RegisterModel
{
    [Required(ErrorMessage = "Username is required.")]
    [MaxLength(50, ErrorMessage = "Username must not exceed 50 characters.")]
    public string? Username { get; set; }

    // Full Name (max 500 characters)
    [Required(ErrorMessage = "Full Name is required.")]
    [MaxLength(500, ErrorMessage = "Full Name must not exceed 500 characters.")]
    public string? FullName { get; set; }

    // Password validation
    [Required(ErrorMessage = "Password is required.")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+={}\[\]|\\:;,.<>?/`~]).{8,16}$",
        ErrorMessage = "Password must contain at least one uppercase letter, one digit, and one special character.")]
    public string? Password { get; set; }

    // Confirm password
    [Required(ErrorMessage = "Password confirmation is required.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string? ConfirmPassword { get; set; }

    // Phone (Ukraine format: +380XXXXXXXXX)
    [Required(ErrorMessage = "Phone number is required.")]
    [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Invalid phone number format.")]
    public string? Phone { get; set; }

    // Email (RFC 822 format)
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string? Email { get; set; }
}
