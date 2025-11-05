namespace ExerciseLibrary.Frontend.Models;

public class ExerciseSummary
{
    public int Id { get; set; }

    public required string Exercise { get; set; }
    
    public required string Genre { get; set; }

    public DateOnly Till { get; set; }
}
