namespace ConsumeApi.Models;

public class UserViewDto
{   public Guid ID {get; set;} 
    public string Username {get; set;} = string.Empty;
    public string Role {get; set;} = "Admin";
}