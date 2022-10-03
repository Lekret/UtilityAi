using UnityEngine;

namespace Ai.Considerations
{
    [CreateAssetMenu(menuName = "StaticData/Considerations/Hunger", fileName = "HungerConsideration")]
    public class HungerConsideration : AiConsideration
    {
        public override float EvaluateScore(AiEntity entity)
        {
            return 0.5f;
        }
    }
}