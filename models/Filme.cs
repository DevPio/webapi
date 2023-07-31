using System.ComponentModel.DataAnnotations;

namespace webapi.Controllers;

public class Filme {

    [Key]
    [Required]
    public int ID { get;  set; }

    [Required(ErrorMessage = "Title is required")]
    public string ?Title { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    [MaxLength(100,ErrorMessage = "")]
    public string ?Gender { get; set; }

    [Range(70,600)]
    public double  Duration { get; set; }
}