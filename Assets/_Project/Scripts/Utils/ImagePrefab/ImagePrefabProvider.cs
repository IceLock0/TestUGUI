using System.Collections.Generic;
using _Project.Scripts.Configs.Inventory;
using UnityEngine.UI;

namespace _Project.Scripts.Utils
{
    public class ImagePrefabProvider : IImagePrefabProvider
    {
        private readonly Dictionary<string, Image> Map = new();

        public ImagePrefabProvider(List<ItemConfig> configs)  
        {
            foreach (var config in configs)
            {
                Map[config.Name] = config.Image;
            }
        }

        public Image GetImage(string name)
        {
            return Map[name];
        }
    }
}