using UnityEngine.UI;

namespace _Project.Scripts.Utils
{
    public interface IImagePrefabProvider
    {
        public Image GetImage(string name);
    }
}