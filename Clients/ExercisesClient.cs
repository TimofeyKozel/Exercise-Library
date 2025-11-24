using ExerciseLibrary.Frontend.Models;

namespace ExerciseLibrary.Frontend.Clients;

public class ExercisesClient(HttpClient httpClient)
{
    public async Task<ExerciseSummary[]> GetExercisesAsync()                            //Die Methoden machen http Requests
        => await httpClient.GetFromJsonAsync<ExerciseSummary[]>("exercises") ?? []; 

    public async Task AddExerciseAsync(ExerciseDetails exercise)
        => await httpClient.PostAsJsonAsync("exercises", exercise);

    public async Task<ExerciseDetails> GetExerciseAsync(int id)
        => await httpClient.GetFromJsonAsync<ExerciseDetails>($"exercises/{id}")
        ?? throw new Exception("Could not find the exercise!");

    public async Task UpdateExerciseAsync(ExerciseDetails updatedExercise)
        => await httpClient.PutAsJsonAsync($"exercises/{updatedExercise.Id}", updatedExercise);

    public async Task DeleteExerciseAsync(int id)
        => await httpClient.DeleteAsync($"exercises/{id}");
}
