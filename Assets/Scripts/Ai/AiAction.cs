﻿using UnityEngine;

namespace Ai
{
    public abstract class AiAction : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private AiConsideration[] _considerations;

        public AiConsideration[] Considerations => _considerations;

        public abstract void Execute(AiEntity entity);

        public static AiAction Copy(AiAction action)
        {
            var instance = Instantiate(action);
            for (var i = 0; i < action._considerations.Length; i++)
            {
                instance._considerations[i] = Instantiate(action._considerations[i]);
            }
            return instance;
        }
    }
}