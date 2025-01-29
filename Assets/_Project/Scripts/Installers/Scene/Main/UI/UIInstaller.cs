using _Project.Scripts.GameOver;
using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.View;
using _Project.Scripts.Weapon.View;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Installers.Scene.Main.UI
{
    public class UIInstaller : MonoInstaller
    {
        [Header("Canvas")]
        [SerializeField] private Canvas _canvas;
        
        [Header("Inventory")]
        [SerializeField] private GridLayoutGroup _gridPrefab;
        [SerializeField] private CellView _cellPrefab;
        [SerializeField] private ItemView _itemPrefab;

        [Header("Popup")]
        [SerializeField] private PopupView _popupPrefab;
        [SerializeField] private ArmorPopupView _armorPopupPrefab;
        [SerializeField] private HealPopupView _healPopupPrefab;
        
        [Header("Player")]
        [SerializeField] private HealthView _playerHealthView; 
        [SerializeField] private PlayerArmorView _playerArmorView;
        [SerializeField] private WeaponView _playerWeaponView;
        
        [Header("GameOver")]
        [SerializeField] private GameOverView _gameOverViewPrefab;
        
        public override void InstallBindings()
        {
            BindCanvas();
            
            BindGridPrefab();
            
            BindCellPrefab();

            BindItemPrefab();
            
            BindPopupPrefab();
            
            BindArmorPopupPrefab();
            
            BindHealPopupPrefab();

            BindPlayerHealthView();
            
            BindPlayerArmorView();

            BindPlayerWeaponView();

            BindGameOverViewPrefab();
        }

        private void BindGameOverViewPrefab()
        {
            Container
                .Bind<GameOverView>()
                .FromInstance(_gameOverViewPrefab)
                .AsSingle();
        }
        
        private void BindPlayerWeaponView()
        {
            Container
                .Bind<WeaponView>()
                .FromInstance(_playerWeaponView)
                .AsSingle();
        }

        private void BindPlayerArmorView()
        {
            Container
                .Bind<PlayerArmorView>()
                .FromInstance(_playerArmorView)
                .AsSingle();
        }
        
        private void BindPlayerHealthView()
        {
            Container
                .Bind<HealthView>()
                .FromInstance(_playerHealthView)
                .AsSingle();
        }
        
        private void BindPopupPrefab()
        {
            Container
                .Bind<PopupView>()
                .FromInstance(_popupPrefab)
                .AsSingle();
        }

        private void BindArmorPopupPrefab()
        {
            Container
                .Bind<ArmorPopupView>()
                .FromInstance(_armorPopupPrefab)
                .AsSingle();
        }

        private void BindHealPopupPrefab()
        {
            Container
                .Bind<HealPopupView>()
                .FromInstance(_healPopupPrefab)
                .AsSingle();
        }
        
        private void BindItemPrefab()
        {
            Container
                .Bind<ItemView>()
                .FromInstance(_itemPrefab)
                .AsSingle();
        }
        
        private void BindCellPrefab()
        {
            Container
                .Bind<CellView>()
                .FromInstance(_cellPrefab)
                .AsSingle();
        }

        private void BindGridPrefab()
        {
            Container
                .Bind<GridLayoutGroup>()
                .FromInstance(_gridPrefab)
                .AsSingle();
        }

        private void BindCanvas()
        {
            Container
                .Bind<Canvas>()
                .FromInstance(_canvas)
                .AsSingle();
        }
    }
}