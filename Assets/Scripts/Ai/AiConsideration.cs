using UnityEngine;

namespace Ai
{
    public abstract class AiConsideration : ScriptableObject
    {
        [SerializeField] private string _name;
        
        public abstract float EvaluateScore(AiEntity entity);
    }
}