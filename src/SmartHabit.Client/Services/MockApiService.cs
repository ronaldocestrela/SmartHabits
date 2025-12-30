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

        private async Task<T?> GetFromStorageAsync<T>(string key)
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", key);
            if (string.IsNullOrEmpty(json)) return default;
            return JsonSerializer.Deserialize<T>(json);
        }

        private async Task SetToStorageAsync<T>(string key, T value)
        {
            var json = JsonSerializer.Serialize(value);
            await _js.InvokeVoidAsync("localStorage.setItem", key, json);
        }

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

        public async Task<List<Habit>> GetHabitsForOwnerAsync(string ownerId)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            return [.. list.Where(h => h.OwnerId == ownerId)];
        }

        public async Task<Habit?> GetHabitAsync(string id)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            return list.FirstOrDefault(h => h.Id == id);
        }

        public async Task AddHabitAsync(Habit habit)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            list.Add(habit);
            await SetToStorageAsync(HabitsKey, list);
        }

        public async Task UpdateHabitAsync(Habit habit)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            var idx = list.FindIndex(h => h.Id == habit.Id);
            if (idx >= 0) { list[idx] = habit; await SetToStorageAsync(HabitsKey, list); }
        }

        public async Task DeleteHabitAsync(string id)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? [];
            list.RemoveAll(h => h.Id == id);
            await SetToStorageAsync(HabitsKey, list);
        }

        public async Task<List<HabitGoal>> GetGoalsForHabitAsync(string habitId)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            return list.Where(g => g.HabitId == habitId).ToList();
        }

        public async Task AddGoalAsync(HabitGoal goal)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            list.Add(goal);
            await SetToStorageAsync(GoalsKey, list);
        }

        public async Task UpdateGoalAsync(HabitGoal goal)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? [];
            var idx = list.FindIndex(g => g.Id == goal.Id);
            if (idx >= 0) { list[idx] = goal; await SetToStorageAsync(GoalsKey, list); }
        }
    }
}