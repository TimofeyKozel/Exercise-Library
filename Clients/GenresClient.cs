using ExerciseLibrary.Frontend.Models;

namespace ExerciseLibrary.Frontend.Clients;

public class GenresClient
{
    private readonly Genre[] genres = [
        new ()
        {
            Id = 1,
            Exercise = "Work"
        },
        new ()
        {
            Id = 2,
            Exercise = "Home"
        },
        new ()
        {
            Id = 3,
            Exercise = "Family"
        },
        new ()
        {
            Id = 4,
            Exercise = "Credits"
        },
        new ()
        {
            Id = 5,
            Exercise = "Sport"
        },
        new ()
        {
            Id = 6,
            Exercise = "Else"
        },
    ];

    public Genre[] GetGenres() => genres;
}
