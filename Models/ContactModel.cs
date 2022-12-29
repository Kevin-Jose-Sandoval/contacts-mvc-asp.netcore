using System.ComponentModel.DataAnnotations;

namespace ContactsApi.Models
{
    public class ContactModel
    {
        public int ContactId { get; set; }
        [Required(ErrorMessage = "The name field is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "The phone field is required")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "The email field is required")]
        public string? Email { get; set; }
    }
}
