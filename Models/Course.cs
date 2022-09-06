using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaltaLearn.Models;

public class Course : ModelBase
{
    [NotMapped]
    public double DurationInHours => DurationInMinutes / 60.00;

    [DisplayName("Duração")]
    [Required(ErrorMessage = "Informe a duração do curso em minutos")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que 0")]
    public int DurationInMinutes { get; set; }

    public ICollection<Module> Modules { get; set; }

    [DisplayName("Sumário")]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MinLength(3, ErrorMessage = "Este campo deve conter no mínimo 3 caracteres")]
    public string Summary { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório")]
    [RegularExpression(@"^\$?\d{4}?$", ErrorMessage = "Informe uma tag para o curso no formato '9999'")]
    [StringLength(4, MinimumLength = 4, ErrorMessage = "Este campo deve conter 4 caracteres")]
    public string Tag { get; set; }

    [DisplayName("Título")]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(100, ErrorMessage = "Este campo deve conter entre 3 e 100 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 100 caracteres")]
    public string Title { get; set; }
}