using UnityEngine;

namespace _Project.Scripts.Configs.Character
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/Characters/Enemy", order = 0)]
    public class EnemyConfig : CharacterConfig
    {
        [SerializeField] private int _damage;
        
        public int Damage => _damage;
    }
}