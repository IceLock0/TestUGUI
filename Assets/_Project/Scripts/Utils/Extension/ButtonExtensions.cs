using UnityEngine.Events;
using UnityEngine.UI;

namespace _Project.Scripts.Utils.Extension
{
    public static class ButtonExtensions
    {
        public static void AddListener(this Button button, UnityAction callback)
        {
            button.onClick.AddListener(callback);
        }

        public static void RemoveListener(this Button button, UnityAction callback)
        {
            button.onClick.RemoveListener(callback);
        }
    }
}