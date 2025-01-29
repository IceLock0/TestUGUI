using System;
using _Project.Scripts.Inventory.Item.Data;
using UnityEngine;

namespace _Project.Scripts.Configs.Character
{
    public abstract class CharacterConfig : ScriptableObject
    {
        [SerializeField] private HealthData _healthData; 
        
        public HealthData HealthData => _healthData;
    }
}