namespace JwtWebapiTutorial.Models;

public class User
{
    public int UserID {get; set;}
    public string Username {get; set;} = string.Empty;
    public byte[] PasswordHash {get; set;}
    public byte[] PasswordSalt {get; set;}
    public string Role {get; set;}
}