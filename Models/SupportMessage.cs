using System.ComponentModel.DataAnnotations;

namespace SupportWebApp.Models;

public class SupportMessage
{
    public string id { get; set; } = Guid.NewGuid().ToString();

    public string category { get; set; } = "support";

    [Required(ErrorMessage = "Navn skal udfyldes")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Email skal udfyldes")]
    [EmailAddress(ErrorMessage = "Indtast en gyldig emailadresse")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Emne skal udfyldes")]
    public string Subject { get; set; } = "";

    [Required(ErrorMessage = "Besked skal udfyldes")]
    public string Message { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}