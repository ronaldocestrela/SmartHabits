using SmartHabit.Client.Models;
using System;

namespace SmartHabit.Client.State
{
    public class AppState
    {
        public event Action? AuthStateChanged;
        public event Action? StateChanged;
        private User? _currentUser;

        public User? CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                AuthStateChanged?.Invoke();
                StateChanged?.Invoke();
            }
        }

        public void NotifyStateChanged()
        {
            StateChanged?.Invoke();
        }
    }
}