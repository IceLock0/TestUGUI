using _Project.Scripts.Configs.Character;
using _Project.Scripts.Inventory.Item.Data;
using _Project.Scripts.Providers.Death;
using _Project.Scripts.Services.LoadSave;
using _Project.Scripts.Utils.Path;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Inventory.Item.View
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image _barImage;
        [SerializeField] private TextMeshProUGUI _valueText;

        [SerializeField] private bool _isPlayer;

        private IDeathProvider _deathProvider;
        private ISaveLoadService _saveLoadService;

        public HealthData HealthData { get; private set; }

        [Inject]
        private void Initialize(PlayerConfig playerConfig, EnemyConfig enemyConfig, IDeathProvider deathProvider,
            ISaveLoadService saveLoadService)
        {
            _saveLoadService = saveLoadService;
            
            var data = _isPlayer
                ? _saveLoadService.Load<HealthData>(SaveKeys.PLAYER_HEALTH)
                : _saveLoadService.Load<HealthData>(SaveKeys.ENEMY_HEALTH);

            var maxHp = _isPlayer ? playerConfig.HealthData.MaxHealth : enemyConfig.HealthData.MaxHealth;
            
            if(data == null)
                SetStartData(maxHp);
            else SetLoadedData(data);
            
            HealthData.Changed += SetInfo;
            HealthData.Died += Refresh;
            SetInfo(HealthData.CurrentHealth, HealthData.MaxHealth);

            _deathProvider = deathProvider;
            _deathProvider.AddHealthData(HealthData);
        }

        private void SetStartData(int maxHp)
        {
            HealthData = new HealthData()
            {
                MaxHealth = maxHp,
                CurrentHealth = maxHp,
                IsPlayer = _isPlayer
            };
        }

        private void SetLoadedData(HealthData healthData)
        {
            HealthData = healthData;
        }

        private void SetInfo(int currentHealth, int maxHealth)
        {
            _barImage.fillAmount = (float)currentHealth / maxHealth;
            _valueText.text = currentHealth.ToString();

            if(currentHealth > 0)
                Save();
        }

        private void Refresh(bool isPlayer)
        {
            if (isPlayer)
                return;

            HealthData.CurrentHealth = HealthData.MaxHealth;
        }

        private void OnDisable()
        {
            HealthData.Changed -= SetInfo;
            HealthData.Died -= Refresh;
        }

        private void OnDestroy()
        {
            _deathProvider.RemoveHealthData(HealthData);
        }

        private void Save()
        {
            _saveLoadService.Save(_isPlayer ? SaveKeys.PLAYER_HEALTH : SaveKeys.ENEMY_HEALTH, HealthData);
        }
    }
}