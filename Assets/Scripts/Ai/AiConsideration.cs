using UnityEngine;

namespace Ai
{
    public abstract class AiConsideration : ScriptableObject
    {
        public abstract float EvaluateScore(AiEntity entity);
    }
}