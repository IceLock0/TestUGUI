using _Project.Scripts.Inventory;
using _Project.Scripts.Inventory.Item.View;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Utils.Factory
{
    public class PopupFactory : IPopupFactory
    {
        private readonly DiContainer _container;

        private readonly Canvas _canvas;

        private readonly PopupView _popupPrefab;
        private readonly ArmorPopupView _armorPopupPrefab;
        private readonly HealPopupView _healPopupPrefab;

        public PopupFactory(DiContainer container, Canvas canvas, PopupView popupPrefab,
            ArmorPopupView armorPopupPrefab, HealPopupView healPopupPrefab)
        {
            _container = container;

            _canvas = canvas;

            _popupPrefab = popupPrefab;
            _armorPopupPrefab = armorPopupPrefab;
            _healPopupPrefab = healPopupPrefab;
        }

        public PopupView CreatePopup(ItemData itemData) => CreateAndInitPopup(itemData);

        private PopupView CreateAndInitPopup(ItemData itemData)
        {
            switch (itemData)
            {
                case ArmorItemData armorItemData:
                {
                    var popup = _container.InstantiatePrefabForComponent<ArmorPopupView>(_armorPopupPrefab, _canvas.transform);
                    popup.SetInfo(armorItemData.Image, armorItemData.Name, armorItemData.Weight,
                        armorItemData.ArmorValue);
                    return popup;
                }
                case HealItemData healItemData:
                {
                    var popup = _container.InstantiatePrefabForComponent<HealPopupView>(_healPopupPrefab, _canvas.transform);
                    popup.SetInfo(healItemData.Image, healItemData.Name, healItemData.Weight, healItemData.HealValue);
                    return popup;
                }
                default:
                {
                    var popup = _container.InstantiatePrefabForComponent<PopupView>(_popupPrefab, _canvas.transform);
                    popup.SetInfo(itemData.Image, itemData.Name, itemData.Weight);
                    return popup;
                }
            } 
        }
    }
}