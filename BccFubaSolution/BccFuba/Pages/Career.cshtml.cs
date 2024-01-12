namespace BccFuba.Pages;
public class CareerModel : PageModel
{
    private readonly IEmailService _emailService;
    private readonly EmailSettings _emailSettings;

    public CareerModel(IEmailService emailService, IOptions<EmailSettings> emailSettings)
    {
        _emailService = emailService;
        _emailSettings = emailSettings.Value;
    }

    [BindProperty]
    public CareerForm CareerForm { get; set; }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page(); // Return the page with validation errors if the model state is invalid
        }

        const string subject = "Job Application";

        var htmlContent = await System.IO.File.ReadAllTextAsync("EmailTemplates/ContactUs.html");
        htmlContent = htmlContent.Replace("__FIRSTNAME__", CareerForm.FirstName);
        htmlContent = htmlContent.Replace("__LASTNAME__", CareerForm.LastName);
        htmlContent = htmlContent.Replace("__EMAIL__", CareerForm.Email);
        htmlContent = htmlContent.Replace("__PHONENUMBER__", CareerForm.PhoneNumber);
        htmlContent = htmlContent.Replace("__MESSAGE__", CareerForm.Message);

        var attachment = new FormFileCollection { CareerForm.File };

        var message = new Message(new[] { _emailSettings.CareersToEmail }, subject, htmlContent, attachment);
        await _emailService.SendEmailAsync(message);

        // Redirect to a thank you page or return a success message
        return RedirectToPage("/ThankYou");
    }
}