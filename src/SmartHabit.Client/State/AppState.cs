using SmartHabit.Client.Models;
using System;

namespace SmartHabit.Client.State
{
    public class AppState
    {
        public event Action? AuthStateChanged;
        private User? _currentUser;

        public User? CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;
                AuthStateChanged?.Invoke();
            }
        }
    }
}