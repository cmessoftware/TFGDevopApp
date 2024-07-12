using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TFGDevopsApp.Infraestructure.Entity.Login;

public class CustomUser //: BaseEntity
{
    public CustomUser()
    {

    }
    public CustomUser(string userName, string password)
    {
        Id = Guid.NewGuid().ToString();
        UserName = userName;
        Password = password;
    }
    public CustomUser(string name, string email, string userName, string password)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        Email = email;
        UserName = userName;
        Password = password;
    }

    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string? UserName { get; internal set; }
    public string? Title { get; set; }
    public string? Name { get; internal set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string RoleId { get; set; }

    [NotMapped]
    public string? Password { get; internal set; }

    public bool? RememberMe { get; set; }


    [JsonIgnore]
    public string? PasswordHash { get; set; }

}