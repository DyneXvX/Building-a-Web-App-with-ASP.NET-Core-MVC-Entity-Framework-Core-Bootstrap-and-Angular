using System.ComponentModel.DataAnnotations;

namespace DutchTreat.ViewModels
{
    public class ContactViewModel
    {
        //this was built to control the data from the Contact Page. Now we can store and use the data received on the form.
        [Required] 
        [MinLength(5)]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]

        public string Subject { get; set; }
        
        [Required(ErrorMessage = "Required")]
        [MaxLength(250, ErrorMessage = "Too Long")]
        public string Message { get; set; }
    }
}