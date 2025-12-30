using System;

namespace SmartHabit.Client.Models
{
    public class HabitGoal
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string HabitId { get; set; } = string.Empty;
        public DateTime StartDate { get; set; } = DateTime.UtcNow.Date;
        public TimeSpan TargetDuration { get; set; } = TimeSpan.Zero; // how much time intended to practice
        public int TargetDays { get; set; } = 0; // optional: number of days
    }
}