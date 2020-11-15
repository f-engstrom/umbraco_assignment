using System.ComponentModel.DataAnnotations;

namespace assignment_2.Models
{
    public class LoginViewModel
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
    }
}