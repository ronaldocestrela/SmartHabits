using SmartHabit.Client.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHabit.Client.Services
{
    public interface IMockApiService
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);

        Task<List<Habit>> GetHabitsForOwnerAsync(string ownerId);
        Task<Habit?> GetHabitAsync(string id);
        Task AddHabitAsync(Habit habit);
        Task UpdateHabitAsync(Habit habit);
        Task DeleteHabitAsync(string id);

        // Goals
        Task<List<HabitGoal>> GetGoalsForHabitAsync(string habitId);
        Task AddGoalAsync(HabitGoal goal);
        Task UpdateGoalAsync(HabitGoal goal);
    }
}