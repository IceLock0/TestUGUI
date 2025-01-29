using _Project.Scripts.Services.ItemDestroyerService;
using _Project.Scripts.Services.ItemUseService;
using _Project.Scripts.Services.LoadSave;
using _Project.Scripts.Services.Loot;
using Zenject;

namespace _Project.Scripts.Installers.Scene.Main.Service
{
    public class ServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLootService();

            BindSaveLoadService();
            
            BindItemDestroyerService();

            BindItemUseService();
        }

        private void BindItemUseService()
        {
            Container
                .Bind<IItemUseService>()
                .To<ItemUseService>()
                .AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();
        }

        private void BindLootService()
        {
            Container
                .BindInterfacesAndSelfTo<LootService>()
                .AsSingle();
        }

        private void BindItemDestroyerService()
        {
            Container
                .Bind<IItemDestroyerService>()
                .To<ItemDestroyerService>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}