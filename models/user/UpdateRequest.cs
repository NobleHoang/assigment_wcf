using System.ComponentModel.DataAnnotations;

namespace baseNetApi.models.user;

public class UpdateRequest
{
    public string firstName { get; set; } = "";
    public string lastName { get; set; } = "";
    [Required]
    public string username { get; set; }
    public string email { get; set; } = "";
    public string phoneNumber { get; set; } = "";
    public string birthday { get; set; } = "";
    public string gender { get; set; } = "";
    public string address { get; set; }  = "";

    [Required]
    [EnumDataType(typeof(Role))]
    public string role { get; set; } = "User";
}