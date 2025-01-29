using System;
using _Project.Scripts.Configs.Weapon;
using _Project.Scripts.Inventory.Item.View;
using _Project.Scripts.Providers.Inventory;
using _Project.Scripts.Utils.Extension;
using _Project.Scripts.Weapon.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Weapon.View
{
    public class WeaponView : MonoBehaviour
    {
        [SerializeField] private HealthView _enemyHealthView;

        [SerializeField] private Button _pistolButton;
        [SerializeField] private Button _rifleButton;
        [SerializeField] private Button _shootButton;

        [SerializeField] private Image _pistolOutlineImage;
        [SerializeField] private Image _rifleOutlineImage;

        [SerializeField] private TextMeshProUGUI _pistolDamageValueText;
        [SerializeField] private TextMeshProUGUI _rifleDamageValueText;

        private PistolConfig _pistolConfig;
        private RifleConfig _rifleConfig;

        private WeaponData _pistolWeaponData;
        private WeaponData _rifleWeaponData;

        private WeaponData _currentWeaponData;

        private IReadOnlyInventoryItemsProvider _readOnlyInventoryItemsProvider;

        public event Action Shooted;

        [Inject]
        private void Initialize(PistolConfig pistolConfig, RifleConfig rifleConfig,
            IReadOnlyInventoryItemsProvider readOnlyInventoryItemsProvider)
        {
            _pistolConfig = pistolConfig;
            _rifleConfig = rifleConfig;

            _readOnlyInventoryItemsProvider = readOnlyInventoryItemsProvider;

            CreateWeapons();

            ChooseNothing();

            SetDamage(pistolConfig.Damage, rifleConfig.Damage);
        }

        private void Shoot()
        {
            if (_currentWeaponData == null)
                return;
                    
            var isShooted = _currentWeaponData.TryToShoot();
            
            if(isShooted)
                Shooted?.Invoke();
        }

        private void CreateWeapons()
        {
            var enemyHealthData = _enemyHealthView.HealthData;

            _pistolWeaponData = new WeaponData(enemyHealthData, _readOnlyInventoryItemsProvider)
            {
                AmmoId = _pistolConfig.AmmoTypeConfig.Name,
                Damage = _pistolConfig.Damage,
                AmmoPerShoot = _pistolConfig.AmmoPerShoot
            };

            _rifleWeaponData = new WeaponData(enemyHealthData, _readOnlyInventoryItemsProvider)
            {
                AmmoId = _rifleConfig.AmmoTypeConfig.Name,
                Damage = _rifleConfig.Damage,
                AmmoPerShoot = _rifleConfig.AmmoPerShoot
            };
        }

        private void ChoosePistol()
        {
            _pistolOutlineImage.gameObject.SetActive(true);
            _rifleOutlineImage.gameObject.SetActive(false);

            _currentWeaponData = _pistolWeaponData;
        }

        private void ChooseRifle()
        {
            _rifleOutlineImage.gameObject.SetActive(true);
            _pistolOutlineImage.gameObject.SetActive(false);

            _currentWeaponData = _rifleWeaponData;
        }

        private void ChooseNothing()
        {
            _rifleOutlineImage.gameObject.SetActive(false);
            _pistolOutlineImage.gameObject.SetActive(false);
        }

        private void SetDamage(int pistolDamage, int rifleDamage)
        {
            _pistolDamageValueText.text = pistolDamage.ToString();
            _rifleDamageValueText.text = rifleDamage.ToString();
        }

        private void OnEnable()
        {
            _pistolButton.AddListener(ChoosePistol);
            _rifleButton.AddListener(ChooseRifle);
            _shootButton.AddListener(Shoot);
        }

        private void OnDisable()
        {
            _pistolButton.RemoveListener(ChoosePistol);
            _rifleButton.RemoveListener(ChooseRifle);
            _shootButton.RemoveListener(Shoot);
        }
    }
}