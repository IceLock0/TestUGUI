using System;
using _Project.Scripts.Enums;
using _Project.Scripts.Inventory.Item.Data;
using _Project.Scripts.Services.LoadSave;
using _Project.Scripts.Utils;
using _Project.Scripts.Utils.Path;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Scripts.Inventory.Item.View
{
    public class PlayerArmorView : MonoBehaviour
    {
        [SerializeField] private Image _headImage;
        [SerializeField] private Image _bodyImage;
        
        [SerializeField] private TextMeshProUGUI _headValue;
        [SerializeField] private TextMeshProUGUI _bodyValue;

        private ISaveLoadService _saveLoadService;
        private IImagePrefabProvider _imagePrefabProvider;
        
        public PlayerArmorData  PlayerArmorData { get; private set; }
        
        [Inject]
        public void Initialize(ISaveLoadService saveLoadService, IImagePrefabProvider imagePrefabProvider)
        {
            _saveLoadService = saveLoadService;
            _imagePrefabProvider = imagePrefabProvider;
            
            var data = _saveLoadService.Load<PlayerArmorData>(SaveKeys.PLAYER_ARMOR);

            if (data != null)
                SetLoadedData(data);
            else SetStartData();
        }

        private void SetLoadedData(PlayerArmorData data)
        {
            PlayerArmorData = data;
            
            if (PlayerArmorData.HeadArmorItemData != null)
            {
                PlayerArmorData.HeadArmorItemData.Image = _imagePrefabProvider.GetImage(PlayerArmorData.HeadArmorItemData.Name);
                SetHeadInfo();
            }
            if (PlayerArmorData.BodyArmorItemData != null)
            {
                PlayerArmorData.BodyArmorItemData.Image = _imagePrefabProvider.GetImage(PlayerArmorData.BodyArmorItemData.Name);
                SetBodyInfo();
            }
        }

        private void SetStartData()
        {
            PlayerArmorData = new PlayerArmorData();
        }
        
        private void SetInfo(ArmorType armorType)
        {
            if(armorType == ArmorType.Head)
                SetHeadInfo();
            else SetBodyInfo();

            _saveLoadService.Save(SaveKeys.PLAYER_ARMOR, PlayerArmorData);
        }
        
        private void SetHeadInfo()
        {
            _headImage.sprite = PlayerArmorData.HeadArmorItemData.Image.sprite;
            _headValue.text = PlayerArmorData.HeadArmorItemData.ArmorValue.ToString();
        }

        private void SetBodyInfo()
        {
            _bodyImage.sprite = PlayerArmorData.BodyArmorItemData.Image.sprite;
            _bodyValue.text = PlayerArmorData.BodyArmorItemData.ArmorValue.ToString();
        }

        private void OnEnable()
        {
            PlayerArmorData.Changed += SetInfo;
        }

        private void OnDisable()
        {
            PlayerArmorData.Changed -= SetInfo;
        }
    }
}