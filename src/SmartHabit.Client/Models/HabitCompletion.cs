using System;

namespace SmartHabit.Client.Models
{
    public class HabitCompletion
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string HabitId { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
        public DateTime Date { get; set; } = DateTime.UtcNow.Date;
        public TimeSpan Duration { get; set; } = TimeSpan.Zero;
        public string? Notes { get; set; }
    }
}