using System.ComponentModel.DataAnnotations;

namespace BccFuba.Models;
public class CareerForm : ContactForm
{
    [AllowedExtensions(new string[] { ".pdf", ".doc" })]
    public IFormFile File { get; set; }
}

public class AllowedExtensionsAttribute : ValidationAttribute
{
    private readonly string[] _extensions;
    public AllowedExtensionsAttribute(string[] extensions)
    {
        _extensions = extensions;
    }

    protected override ValidationResult IsValid(
    object value, ValidationContext validationContext)
    {
        var file = value as IFormFile;
        if (file != null)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!_extensions.Contains(extension.ToLower()))
            {
                return new ValidationResult(GetErrorMessage());
            }
        }

        return ValidationResult.Success;
    }

    public string GetErrorMessage()
    {
        return $"Invalid file type. Only '.doc', '.docx' and '.pdf' are allowed to upload!";
    }
}