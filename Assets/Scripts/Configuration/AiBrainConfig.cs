using System;
using Ai;
using UnityEngine;

namespace Configuration
{
    [CreateAssetMenu(menuName = "StaticData/AiBrain", fileName = "AiBrain")]
    public class AiBrainConfig : ScriptableObject
    {
        [SerializeField] private AiAction[] _actions;
        
        public AiAction[] GetActionsCopy()
        {
            return Array.ConvertAll(_actions, AiAction.Copy);
        }
    }
}