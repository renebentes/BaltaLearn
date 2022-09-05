using System.ComponentModel.DataAnnotations;

namespace BaltaLearn.Entities;

public abstract class ModelBase
{
    [Key]
    public int Id { get; set; }
}