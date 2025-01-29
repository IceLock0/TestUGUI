using _Project.Scripts.Services.ItemDestroyerService;
using _Project.Scripts.Services.ItemUseService;
using _Project.Scripts.Utils.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.Inventory.Item.View
{
    public class ItemView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _sourceImage;
        [SerializeField] private TextMeshProUGUI _countText;

        private ItemData _itemData;

        private IPopupFactory _popupFactory;
        private PopupView _currentPopup;

        private IItemDestroyerService _itemDestroyerService;
        private IItemUseService _itemUseService;

        public void Initialize(ItemData itemData, IPopupFactory popupFactory,
            IItemDestroyerService itemDestroyerService, IItemUseService itemUseService)
        {
            _itemData = itemData;
            _itemData.CountChanged += SetInfo;
            _popupFactory = popupFactory;

            _itemDestroyerService = itemDestroyerService;
            _itemUseService = itemUseService;
            
            SetInfo(itemData.Count);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _currentPopup = _popupFactory.CreatePopup(_itemData);

            _currentPopup.RemoveButtonClicked += DestroyItem;
            _currentPopup.UseButtonClicked += UseItem;
        }

        private void SetInfo(int count)
        {
            _sourceImage.sprite = _itemData.Image.sprite;
            
            switch (count)
            {
                case > 1:
                    _countText.text = _itemData.Count.ToString();
                    break;
                case 1:
                    _countText.text = "";
                    break;
                case <= 0:
                    DestroyItem();
                    break;
            }
        }

        private void UseItem()
        {
           _itemUseService.Use(_itemData);

            DestroyPopup();
        }

        private void DestroyItem()
        {
            if(_currentPopup != null)
                DestroyPopup();
            
            _itemDestroyerService.DestroyItem(_itemData, this);
        }

        private void OnDisable()
        {
            _itemData.CountChanged -= SetInfo;
        }

        private void DestroyPopup()
        {
            _currentPopup.RemoveButtonClicked -= DestroyItem;
            _currentPopup.UseButtonClicked -= UseItem;

            Destroy(_currentPopup.gameObject);
        }
    }
}