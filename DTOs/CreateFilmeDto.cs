
using System.ComponentModel.DataAnnotations;

namespace webapi.Controllers;


public class CreateFilmeDto {
    
    

    [Required(ErrorMessage = "Title is required")]
    public string ?Title { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    [StringLength(100,ErrorMessage = "")]
    public string ?Gender { get; set; }

    [Range(70,600)]
    public double  Duration { get; set; }
}