using _Project.Scripts.Providers.Death;
using _Project.Scripts.Providers.Inventory;
using _Project.Scripts.Utils;
using Zenject;

namespace _Project.Scripts.Installers.Scene.Main.Provider
{
    public class ProvidersInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindDeathProvider();
            
            BindReadOnlyInventoryItemsProvider();
            
            Container.Bind<IImagePrefabProvider>().To<ImagePrefabProvider>().AsSingle();
        }

        private void BindDeathProvider()
        {
            Container
                .Bind<IDeathProvider>()
                .To<DeathProvider>()
                .AsSingle();
        }
        
        private void BindReadOnlyInventoryItemsProvider()
        {
            Container
                .Bind<IReadOnlyInventoryItemsProvider>()
                .To<ReadOnlyInventoryItemsProvider>()
                .AsSingle();
        }
    }
}