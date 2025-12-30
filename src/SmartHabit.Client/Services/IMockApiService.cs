using SmartHabit.Client.Models;

namespace SmartHabit.Client.Services
{
    public interface IMockApiService
    {
        // Users
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);

        // Habits
        Task<List<Habit>> GetHabitsByUserAsync(string userId);
        Task<List<Habit>> GetHabitsForOwnerAsync(string ownerId);
        Task<Habit?> GetHabitAsync(string id);
        Task AddHabitAsync(Habit habit);
        Task UpdateHabitAsync(Habit habit);
        Task DeleteHabitAsync(string id);

        // Goals
        Task<List<HabitGoal>> GetGoalsForHabitAsync(string habitId);
        Task<List<HabitGoal>> GetGoalsByUserAsync(string userId);
        Task<HabitGoal?> GetGoalAsync(string id);
        Task AddGoalAsync(HabitGoal goal);
        Task UpdateGoalAsync(HabitGoal goal);
        Task DeleteGoalAsync(string id);

        // Completions
        Task<List<HabitCompletion>> GetCompletionsByUserAsync(string userId);
        Task<List<HabitCompletion>> GetCompletionsByDateAsync(string userId, DateTime date);
        Task<List<HabitCompletion>> GetCompletionsByHabitAsync(string habitId);
        Task<HabitCompletion?> GetCompletionAsync(string id);
        Task AddCompletionAsync(HabitCompletion completion);
        Task UpdateCompletionAsync(HabitCompletion completion);
        Task DeleteCompletionAsync(string id);
    }
}