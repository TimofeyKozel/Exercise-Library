using ExerciseLibrary.Frontend.Models;

namespace ExerciseLibrary.Frontend.Clients;

public class ExercisesClient(HttpClient httpClient)
{
    public async Task<ExerciseSummary[]> GetExercisesAsync()
        => await httpClient.GetFromJsonAsync<ExerciseSummary[]>("exercises") ?? [];

    public async Task AddExerciseAsync(ExerciseDetails exercise)
        => await httpClient.PostAsJsonAsync("exercises", exercise);

    public async Task<ExerciseDetails> GetExerciseAsync(int id)
        => await httpClient.GetFromJsonAsync<ExerciseDetails>($"exericses/{id}")
        ?? throw new Exception("Could not find the game!");

    public async Task UpdateExerciseAsync(ExerciseDetails updateExercise)
        => await httpClient.PutAsJsonAsync($"exercises/{updateExercise.Id}", updateExercise);

    public async Task DeleteExerciseAsync(int id)
        => await httpClient.DeleteAsync($"exercises/{id}");
}
