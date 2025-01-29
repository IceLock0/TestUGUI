using _Project.Scripts.Bootstrap;
using _Project.Scripts.Inventory.Item.View;
using _Project.Scripts.Providers.Inventory;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Installers.Scene.Main.MainInstaller
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBootstrapper();

            BindInventory();
        }

        private void BindBootstrapper()
        {
            Container
                .BindInterfacesAndSelfTo<Bootstrapper>()
                .AsSingle()
                .NonLazy();
        }

        private void BindInventory()
        {
            Container
                .BindInterfacesAndSelfTo<Inventory.Inventory>()
                .AsSingle();
        }
    }
}