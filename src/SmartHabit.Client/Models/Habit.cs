using System;

namespace SmartHabit.Client.Models
{
    public class Habit
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string OwnerId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}