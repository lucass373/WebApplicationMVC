using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter a Email")]
        [EmailAddress(ErrorMessage = "Enter a valid Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Enter a Phone")]
        [Phone(ErrorMessage = "Enter a valid Phone")]
        public string Phone { get; set; }
    }
}
