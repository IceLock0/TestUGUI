using System;
using _Project.Scripts.Inventory.Item.Data;

namespace _Project.Scripts.Providers.Death
{
    public interface IDeathProvider
    {
        public void AddHealthData(HealthData healthData);
        public void RemoveHealthData(HealthData healthData);
        
        public event Action OnEnemyDeath;
    }
}