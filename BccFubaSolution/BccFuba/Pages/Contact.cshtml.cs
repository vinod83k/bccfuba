using BccFuba.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BccFuba.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public ContactForm ContactForm { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return the page with validation errors if the model state is invalid
            }

            // Process the form data (e.g., send email, save to database)

            // Redirect to a thank you page or return a success message
            return RedirectToPage("/ThankYou");
        }
    }
}
