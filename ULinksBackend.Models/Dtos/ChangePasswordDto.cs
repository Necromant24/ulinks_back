namespace UsefulLinksBackend.Models;

public class ChangePasswordDto
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
}