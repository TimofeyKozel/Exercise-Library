using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExerciseLibrary.Frontend.Models;

public class ExerciseDetails
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Exercise { get; set; }
    
    [Required(ErrorMessage = "The Genre field is required.")]
    
    public int? GenreId { get; set; }

    public DateOnly Till { get; set; }
}
