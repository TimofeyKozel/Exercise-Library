using ExerciseLibrary.Frontend.Models;

namespace ExerciseLibrary.Frontend.Clients;

public class ExercisesClient
{
    private readonly List<ExerciseSummary> exercises =
    [
        new(){
            Id = 1,
            Exercise = "ein Haus kaufen",
            Genre = "Home",
            Till = new DateOnly(2026, 12, 12)
        },
        new(){
            Id = 2,
            Exercise = "ein Auto kaufen",
            Genre = "Else",
            Till = new DateOnly(2025, 11, 28)
        },
        new(){
            Id = 3,
            Exercise = "ein Project fertig machen",
            Genre = "Else",
            Till = new DateOnly(2025, 11, 23)
        },
        new(){
            Id = 4,
            Exercise = "gitHub joy",
            Genre = "Else",
            Till = new DateOnly(2025, 11, 23)
        }
                
    ];

    private readonly Genre[] genres = new GenresClient().GetGenres();

    public ExerciseSummary[] GetExercises => [.. exercises];

    public void AddExercise(ExerciseDetails exercise)
    {
        Genre genre = GetGenreById(exercise.GenreId);

        var exerciseSummary = new ExerciseSummary
        {
            Id = exercises.Count + 1,
            Exercise = exercise.Exercise,
            Genre = genre.Exercise,
            Till = exercise.Till
        };

        exercises.Add(exerciseSummary);
    }

    public ExerciseDetails GetExercise(int id)
    {
        ExerciseSummary exercise = GetExerciseSummaryById(id);

        var genre = genres.Single(genre => string.Equals(
            genre.Exercise,
            exercise.Genre,
            StringComparison.OrdinalIgnoreCase));

        return new ExerciseDetails
        {
            Id = exercise.Id,
            Exercise = exercise.Exercise,
            GenreId = genre.Id.ToString(),
            Till = exercise.Till
        };
    }

    public void UpdateExercise(ExerciseDetails updateExercise)
    {
        var genre = GetGenreById(updateExercise.GenreId);
        ExerciseSummary existingExercise = GetExerciseSummaryById(updateExercise.Id);

        existingExercise.Exercise = updateExercise.Exercise;
        existingExercise.Genre = genre.Exercise;
        existingExercise.Till = updateExercise.Till;
    }

    public void DeleteExercise(int id)
    {
        var exercise = GetExerciseSummaryById(id);
        exercises.Remove(exercise);
    }

    private ExerciseSummary GetExerciseSummaryById(int id)
    {
        ExerciseSummary? exercise = exercises.Find(exercise => exercise.Id == id);
        ArgumentNullException.ThrowIfNull(exercise);
        return exercise;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }
}
