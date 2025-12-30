using System;

namespace SmartHabit.Client.Models
{
    public class Habit
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OwnerId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public HabitCategory Category { get; set; } = HabitCategory.Other;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastCompletedAt { get; set; }
        public int CurrentStreak { get; set; } = 0;
        public int BestStreak { get; set; } = 0;
        public int TotalCompletions { get; set; } = 0;
    }

    public enum HabitCategory
    {
        Health,
        Fitness,
        Study,
        Work,
        Social,
        Creative,
        Other
    }
}