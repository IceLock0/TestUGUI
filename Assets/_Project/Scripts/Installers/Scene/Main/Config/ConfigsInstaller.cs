using System.Collections.Generic;
using _Project.Scripts.Configs.Character;
using _Project.Scripts.Configs.Inventory;
using _Project.Scripts.Configs.Weapon;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace _Project.Scripts.Installers.Scene.Main.ConfigsInstaller
{
    public class ConfigsInstaller : MonoInstaller
    {
        [Header("Inventory")]
        [SerializeField] private GridConfig _gridConfig;
        [SerializeField] private List<ItemConfig> _lootItemConfigs;

        [Header("Configs")]
        [Space(2)]
        
        [Header("Character")]
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyConfig _enemyConfig;

        [Space(1)] 
        [Header("Weapon")] 
        [SerializeField] private PistolConfig _pistolConfig;
        [SerializeField] private RifleConfig _rifleConfig;

        public override void InstallBindings()
        {
            BindGridConfig();

            BindPlayerConfig();

            BindEnemyConfig();

            BindPistolConfig();

            BindRifleConfig();

            BindLootItemConfig();
        }

        private void BindLootItemConfig()
        {
            Container
                .Bind<List<ItemConfig>>()
                .FromInstance(_lootItemConfigs)
                .AsSingle();
        }
        
        private void BindRifleConfig()
        {
            Container
                .Bind<RifleConfig>()
                .FromInstance(_rifleConfig)
                .AsSingle();
        }
        
        private void BindPistolConfig()
        {
            Container
                .Bind<PistolConfig>()
                .FromInstance(_pistolConfig)
                .AsSingle();
        }

        private void BindGridConfig()
        {
            Container
                .Bind<GridConfig>()
                .FromInstance(_gridConfig)
                .AsSingle();
        }

        private void BindPlayerConfig()
        {
            Container
                .Bind<PlayerConfig>()
                .FromInstance(_playerConfig)
                .AsSingle();
        }

        private void BindEnemyConfig()
        {
            Container
                .Bind<EnemyConfig>()
                .FromInstance(_enemyConfig)
                .AsSingle();
        }
    }
}