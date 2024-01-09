namespace BccFuba.Pages;

public class ContactModel : PageModel
{
    private readonly IEmailService _emailService;
    private readonly EmailSettings _emailSettings;

    public ContactModel(IEmailService emailService, IOptions<EmailSettings> emailSettings)
    {
        _emailService = emailService;
        _emailSettings = emailSettings.Value;
    }

    [BindProperty]
    public ContactForm ContactForm { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page(); // Return the page with validation errors if the model state is invalid
        }

        const string subject = "Customer Query";

        var htmlContent = await System.IO.File.ReadAllTextAsync("EmailTemplates/ContactUs.html");
        htmlContent = htmlContent.Replace("__FIRSTNAME__", ContactForm.FirstName);
        htmlContent = htmlContent.Replace("__LASTNAME__", ContactForm.LastName);
        htmlContent = htmlContent.Replace("__EMAIL__", ContactForm.Email);
        htmlContent = htmlContent.Replace("__PHONENUMBER__", ContactForm.PhoneNumber);
        htmlContent = htmlContent.Replace("__MESSAGE__", ContactForm.Message);


        var message = new Message(new[] { _emailSettings.AdminToEmail }, subject, htmlContent);
        await _emailService.SendEmailAsync(message);

        // Redirect to a thank you page or return a success message
        return RedirectToPage("/ThankYou");
    }
}