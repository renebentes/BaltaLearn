using System.ComponentModel.DataAnnotations;

namespace BaltaLearn.Models;

public abstract class ModelBase
{
    [Key]
    public int Id { get; set; }
}