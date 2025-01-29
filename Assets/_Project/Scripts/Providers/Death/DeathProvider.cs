using System;
using System.Collections.Generic;
using _Project.Scripts.GameOver;
using _Project.Scripts.Inventory.Item.Data;
using _Project.Scripts.Services.LoadSave;
using _Project.Scripts.Utils.Path;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Providers.Death
{
    public class DeathProvider : IDeathProvider
    {
        private readonly List<HealthData> _healthData = new();
        private readonly GameOverView _gameOverViewPrefab;
        private readonly Canvas _canvas;
        private readonly ISaveLoadService _saveLoadService;

        public event Action OnEnemyDeath;
        
        public DeathProvider(GameOverView gameOverViewPrefab, Canvas canvas, ISaveLoadService saveLoadService)
        {
            _gameOverViewPrefab = gameOverViewPrefab;
            _canvas = canvas;
            _saveLoadService = saveLoadService;
        }
        
        public void AddHealthData(HealthData healthData)
        {
            if (_healthData.Contains(healthData))
                return;
            
            _healthData.Add(healthData);
            
            healthData.Died += OnDeath;
        }

        public void RemoveHealthData(HealthData healthData)
        {
            if (_healthData.Contains(healthData))
                return;
            
            _healthData.Add(healthData);
            
            healthData.Died -= OnDeath;
        }

        private void OnDeath(bool isPLayer)
        {
            if (isPLayer)
            {
                RefreshData();
                Object.Instantiate(_gameOverViewPrefab, _canvas.transform);
            }
            else
                OnEnemyDeath?.Invoke();
        }

        private void RefreshData()
        {
            _saveLoadService.Clean(SaveKeys.ITEMS);
            _saveLoadService.Clean(SaveKeys.PLAYER_HEALTH);
            _saveLoadService.Clean(SaveKeys.ENEMY_HEALTH);
            _saveLoadService.Clean(SaveKeys.PLAYER_ARMOR);
        }
    }
}