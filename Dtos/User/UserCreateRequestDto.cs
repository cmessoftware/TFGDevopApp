using System.ComponentModel.DataAnnotations;

namespace TFGDevopsApp1.Core.Models;

public class UserCreateResponseDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    [MaxLength(20)]
    public string UserName { get; set; }


}