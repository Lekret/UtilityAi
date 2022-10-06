﻿using UnityEngine;

namespace Ai
{
    public abstract class AiConsideration : ScriptableObject
    {
        public virtual void Init() { }

        public abstract float EvaluateScore(AiEntity entity);
    }
}