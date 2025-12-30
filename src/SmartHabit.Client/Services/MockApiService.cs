using Microsoft.JSInterop;
using SmartHabit.Client.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartHabit.Client.Services
{
    public class MockApiService : IMockApiService
    {
        private readonly IJSRuntime _js;
        private const string UsersKey = "smarthabit_users";
        private const string HabitsKey = "smarthabit_habits";
        private const string GoalsKey = "smarthabit_goals";

        public MockApiService(IJSRuntime js)
        {
            _js = js;
        }

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
            var list = await GetFromStorageAsync<List<User>>(UsersKey) ?? new List<User>();
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
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? new List<Habit>();
            return list.Where(h => h.OwnerId == ownerId).ToList();
        }

        public async Task<Habit?> GetHabitAsync(string id)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? new List<Habit>();
            return list.FirstOrDefault(h => h.Id == id);
        }

        public async Task AddHabitAsync(Habit habit)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? new List<Habit>();
            list.Add(habit);
            await SetToStorageAsync(HabitsKey, list);
        }

        public async Task UpdateHabitAsync(Habit habit)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? new List<Habit>();
            var idx = list.FindIndex(h => h.Id == habit.Id);
            if (idx >= 0) { list[idx] = habit; await SetToStorageAsync(HabitsKey, list); }
        }

        public async Task DeleteHabitAsync(string id)
        {
            var list = await GetFromStorageAsync<List<Habit>>(HabitsKey) ?? new List<Habit>();
            list.RemoveAll(h => h.Id == id);
            await SetToStorageAsync(HabitsKey, list);
        }

        public async Task<List<HabitGoal>> GetGoalsForHabitAsync(string habitId)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? new List<HabitGoal>();
            return list.Where(g => g.HabitId == habitId).ToList();
        }

        public async Task AddGoalAsync(HabitGoal goal)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? new List<HabitGoal>();
            list.Add(goal);
            await SetToStorageAsync(GoalsKey, list);
        }

        public async Task UpdateGoalAsync(HabitGoal goal)
        {
            var list = await GetFromStorageAsync<List<HabitGoal>>(GoalsKey) ?? new List<HabitGoal>();
            var idx = list.FindIndex(g => g.Id == goal.Id);
            if (idx >= 0) { list[idx] = goal; await SetToStorageAsync(GoalsKey, list); }
        }
    }
}