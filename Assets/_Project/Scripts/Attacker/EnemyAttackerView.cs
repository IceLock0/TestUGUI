using _Project.Scripts.Configs.Character;
using _Project.Scripts.Inventory.Item.Data;
using _Project.Scripts.Inventory.Item.View;
using _Project.Scripts.Services.LoadSave;
using _Project.Scripts.Weapon.View;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Attacker
{
    public class EnemyAttackerView : MonoBehaviour
    {
        private WeaponView _weaponView;

        private HealthData _playerHealthData;

        private PlayerArmorView _playerArmorView;

        private EnemyConfig _enemyConfig;

        private bool _isHeadAttack = true;

        private ISaveLoadService _saveLoadService;
        
        [Inject]
        private void Initialize(WeaponView weaponView, EnemyConfig enemyConfig, HealthView playerHealthView,
            PlayerArmorView playerArmorView, ISaveLoadService saveLoadService)
        {
            _weaponView = weaponView;

            _enemyConfig = enemyConfig;

            _playerHealthData = playerHealthView.HealthData;
            _playerArmorView = playerArmorView;

            _weaponView.Shooted += Attack;
            
            _saveLoadService = saveLoadService;
        }

        private void Attack()
        {
            var targetDamage = _enemyConfig.Damage;

            var armorData = _playerArmorView.PlayerArmorData;

            if (_isHeadAttack)
            {
                if (armorData.HeadArmorItemData != null)
                    targetDamage -= armorData.HeadArmorItemData.ArmorValue;

                _isHeadAttack = false;
            }
            else
            {
                if (armorData.BodyArmorItemData != null)
                    targetDamage -= armorData.BodyArmorItemData.ArmorValue;

                _isHeadAttack = true;
            }

            _playerHealthData.CurrentHealth -= targetDamage;
            
        }

        private void OnDisable()
        {
            _weaponView.Shooted -= Attack;
        }
    }
}