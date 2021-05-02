using System.ComponentModel.DataAnnotations;

namespace WebCommand.Dtos
{
public class CommandCreateDTO
{
    [Required]
    public string HowTo { get; set; }
    [Required]
    public string line { get; set; }
    [Required]
    public string platform {get; set; }

}

}
