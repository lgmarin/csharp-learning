namespace JwtWebapiTutorial.Models;

// User Data Transfer Object -- Will be used for login and register, not for actual database controller
public class UserDto
{
    public string Username {get; set;} = string.Empty;
    public string Password {get; set;} = string.Empty;
    public string Role {get; set;} = "Admin";
}