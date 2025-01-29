using _Project.Scripts.Utils.Factory;
using _Project.Scripts.Utils.Factory.ItemFactory;
using Zenject;

namespace _Project.Scripts.Installers.Scene.Main.FactoryInstaller
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGridFactory();

            BindItemFactory();

            BindPopupFactory();
        }

        private void BindPopupFactory()
        {
            Container
                .Bind<IPopupFactory>()
                .To<PopupFactory>()
                .AsSingle();
        }

        private void BindItemFactory()
        {
            Container
                .Bind<IItemFactory>()
                .To<ItemFactory>()
                .AsSingle();
        }

        private void BindGridFactory()
        {
            Container
                .Bind<IGridFactory>()
                .To<GridFactory>()
                .AsSingle();
        }
    }
}