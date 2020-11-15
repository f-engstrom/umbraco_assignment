using System.ComponentModel.DataAnnotations;

namespace assignment_2.Models
{
    public class ContactFormViewModel
    {
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Email { get; set; }
        [Required] 
        public string Message  { get; set; }

        
    }
}