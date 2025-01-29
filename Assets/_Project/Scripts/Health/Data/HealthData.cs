using System;

namespace _Project.Scripts.Inventory.Item.Data
{
    [Serializable]
    public class HealthData
    {
        public int MaxHealth;

        public bool IsPlayer;
        
        private int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Math.Min(value, MaxHealth);
                if (_currentHealth <= 0)
                    Died?.Invoke(IsPlayer);
                
                Changed?.Invoke(_currentHealth, MaxHealth);
            }
        }

        public event Action<int, int> Changed;
        public event Action<bool> Died;
    }
}