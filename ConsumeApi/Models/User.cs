using System.ComponentModel.DataAnnotations;

namespace ConsumeApi.Models;

public class User
{
    [Key]
    public Guid ID {get; set;} 
    public string Username {get; set;} = string.Empty;
    public byte[] PasswordHash {get; set;}
    public byte[] PasswordSalt {get; set;}
    public string Role {get; set;}
}