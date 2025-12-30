using Microsoft.JSInterop;
using SmartHabit.Client.Models;
using System.Text.Json;

namespace SmartHabit.Client.Services
{
    public class MockApiService(IJSRuntime js) : IMockApiService
    {
        private readonly IJSRuntime _js = js;
        private const string UsersKey = "smarthabit_users";
        private const string HabitsKey = "smarthabit_habits";
        private const string GoalsKey = "smarthabit_goals";
        private const string CompletionsKey = "smarthabit_completions";

        private async Task<T?> GetFromStorageAsync<T>(string key)
        {
            try
            {
                var json = await _js.InvokeAsync<string>("localStorage.getItem", key);
                if (string.IsNullOrEmpty(json)) return default;
                return JsonSerializer.Deserialize<T>(json);
            }
            catch
            {
                return default;
            }
        }

        private async Task SetToStorageAsync<T>(string key, T value)
        {
            try
            {
                var json = JsonSerializer.Serialize(value);
                await _js.InvokeVoidAsync("localStorage.setItem", key, json);
            }
            catch
            {
                // Handle storage errors silently
            }
        }

        // Users
        public async Task<List<User>> GetUsersAsync()
        {
            var list = await GetFromStorageAsync<List<User>>(UsersKey) ?? [];
            return list;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var users = await GetUsersAsync();
            return users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task AddUserAsync(User user)
        {
            var users = await GetUsersAsync();
            users.Add(user);
            await SetToStorageAsync(UsersKey, users);
        }

        public async Task UpdateUserAsync(User user)
        {
            var users = await GetUsersAsync();
            var idx = users.FindIndex(u => u.Id == user.Id);
            if (idx >= 0) 
            { 
                users[idx] = user; 
                await SetToStorageAsync(UsersKey, users); 
            }
        }

        // Habits
        public async Task<List<Habit>> GetHabitsByUserAsync(string userId)
        {
            return await GetHabitsForOwnerAsync(userId);
        }

        public async Task<List<Habit>> GetHabitsForOwnerAsync(string ownerId)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            return [.. list.Where(h => h.OwnerId == ownerId && h.IsActive)];
        }

        public async Task<Habit?> GetHabitAsync(string id)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            return list.FirstOrDefault(h => h.Id == id);
        }

        public async Task AddHabitAsync(Habit habit)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            habit.CreatedAt = DateTime.UtcNow;
            list.Add(habit);
            await SetToStorageAsync(HabitsKey, list);
        }

        public async Task UpdateHabitAsync(Habit habit)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            var idx = list.FindIndex(h => h.Id == habit.Id);
            if (idx >= 0) 
            { 
                list[idx] = habit; 
                await SetToStorageAsync(HabitsKey, list); 
            }
        }

        public async Task DeleteHabitAsync(string id)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            var habit = list.FirstOrDefault(h => h.Id == id);
            if (habit != null)
            {
                habit.IsActive = false; // Soft delete
                await SetToStorageAsync(HabitsKey, list);
            }
        }

        // Goals
        public async Task<List<HabitGoal>> GetGoalsForHabitAsync(string habitId)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            return list.Where(g => g.HabitId == habitId).ToList();
        }

        public async Task<List<HabitGoal>> GetGoalsByUserAsync(string userId)
        {
            var userHabits = await GetHabitsByUserAsync(userId);
            var habitIds = userHabits.Select(h => h.Id).ToHashSet();
            var goals = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            return goals.Where(g => habitIds.Contains(g.HabitId)).ToList();
        }

        public async Task<HabitGoal?> GetGoalAsync(string id)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            return list.FirstOrDefault(g => g.Id == id);
        }

        public async Task AddGoalAsync(HabitGoal goal)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            goal.CreatedAt = DateTime.UtcNow;
            list.Add(goal);
            await SetToStorageAsync(GoalsKey, list);
        }

        public async Task UpdateGoalAsync(HabitGoal goal)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            var idx = list.FindIndex(g => g.Id == goal.Id);
            if (idx >= 0) 
            { 
                list[idx] = goal; 
                await SetToStorageAsync(GoalsKey, list); 
            }
        }

        public async Task DeleteGoalAsync(string id)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            list.RemoveAll(g => g.Id == id);
            await SetToStorageAsync(GoalsKey, list);
        }

        // Completions
        public async Task<List<HabitCompletion>> GetCompletionsByUserAsync(string userId)
        {
            var list = await GetFromStorageAsync<List<HabitCompletion>>(CompletionsKey) ?? [];
            return list.Where(c => c.UserId == userId).ToList();
        }

        public async Task<List<HabitCompletion>> GetCompletionsByDateAsync(string userId, DateTime date)
        {
            var list = await GetFromStorageAsync<List<HabitCompletion>>(CompletionsKey) ?? [];
            return list.Where(c => c.UserId == userId && c.Date.Date == date.Date).ToList();
        }

        public async Task<List<HabitCompletion>> GetCompletionsByHabitAsync(string habitId)
        {
            var list = await GetFromStorageAsync<List<HabitCompletion>>(CompletionsKey) ?? [];
            return list.Where(c => c.HabitId == habitId).ToList();
        }

        public async Task<HabitCompletion?> GetCompletionAsync(string id)
        {
            var list = await GetFromStorageAsync<List<HabitCompletion>>(CompletionsKey) ?? [];
            return list.FirstOrDefault(c => c.Id == id);
        }

        public async Task AddCompletionAsync(HabitCompletion completion)
        {
            var list = await GetFromStorageAsync<List<HabitCompletion>>(CompletionsKey) ?? [];
            completion.CompletedAt = DateTime.UtcNow;
            list.Add(completion);
            await SetToStorageAsync(CompletionsKey, list);
        }

        public async Task UpdateCompletionAsync(HabitCompletion completion)
        {
            var list = await GetFromStorageAsync<List<HabitCompletion>>(CompletionsKey) ?? [];
            var idx = list.FindIndex(c => c.Id == completion.Id);
            if (idx >= 0) 
            { 
                list[idx] = completion; 
                await SetToStorageAsync(CompletionsKey, list); 
            }
        }

        public async Task DeleteCompletionAsync(string id)
        {
            var list = await GetFromStorageAsync<List<HabitCompletion>>(CompletionsKey) ?? [];
            list.RemoveAll(c => c.Id == id);
            await SetToStorageAsync(CompletionsKey, list);
        }
    }
}