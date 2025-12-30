using System;

namespace SmartHabit.Client.Models
{
    public class HabitGoal
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string HabitId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow.Date;
        public DateTime? EndDate { get; set; }
        public GoalType Type { get; set; } = GoalType.Daily;
        public int TargetCount { get; set; } = 1; // Quantas vezes por período
        public TimeSpan? TargetDuration { get; set; } // Duração alvo por sessão
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum GoalType
    {
        Daily,      // Diário
        Weekly,     // Semanal
        Monthly,    // Mensal
        Custom      // Período personalizado
    }
}