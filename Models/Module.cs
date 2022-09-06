using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BaltaLearn.Models;

public class Module : ModelBase
{
    [Required(ErrorMessage = "Informe a que curso este módulo faz parte.")]
    public Course Course { get; set; }

    [DisplayName("Descrição")]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MinLength(3, ErrorMessage = "Este campo deve conter no mínimo 3 caracteres")]
    public string Description { get; set; }

    [DisplayName("Ordem")]
    [Required(ErrorMessage = "Informe a ordem do módulo.")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que 0")]
    public ushort Order { get; set; }

    [DisplayName("Título")]
    [Required(ErrorMessage = "Este campo é obrigatório")]
    [MaxLength(100, ErrorMessage = "Este campo deve conter entre 3 e 100 caracteres")]
    [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 100 caracteres")]
    public string Title { get; set; }
}