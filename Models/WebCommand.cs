using System.ComponentModel.DataAnnotations;

namespace WebCommand.Models
{
public class Command
{
    [Key]
    public int id {get; set; }  

    [Required]
    [MaxLength(250)]
    public string HowTo { get; set; }
    [Required]
    [MaxLength(250)]
    public string line { get; set; }
    [Required]
    [MaxLength(250)]
    public string platform {get; set; }

}

}
